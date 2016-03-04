// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.WPF.Common;
using Client.WPF._FileStreamService;
using Sketch.FileSystem;

namespace Client.WPF.ViewModels
{
    public sealed class CopyFileViewModel : INotifyPropertyChanged
    {
        private readonly Tuple<string, FileEntry> _source;
        private readonly Tuple<string, DirectoryEntry> _destination;

        private int _progress;

        public CopyFileViewModel(Tuple<string, FileEntry> source, Tuple<string, DirectoryEntry> destination)
        {
            _source = source;
            _destination = destination;

            Progress = "0";
        }

        public string From { get { return _source.Item2.FullName; } }

        public string To { get { return _destination.Item2.FullName; } }

        public string Progress
        {
            get
            {
                return _progress.ToString();
            }

            set
            {
                _progress = int.Parse(value);
                
                OnPropertyChanged();
            }
        }

        public ICommand Start
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        Task.Factory.StartNew(() =>
                        {
                            var bytes = 10*1024*1024; // 10MB
                            var source = CreateClient(_source.Item1);
                            var destination = CreateClient(_destination.Item1);

                            source.Initialize(_source.Item2.FullName, FileMode.Open);
                            destination.Initialize(Path.Combine(_destination.Item2.FullName, _source.Item2.Name),
                                FileMode.CreateNew);

                            var total = source.get_Length();
                            long read = 0;

                            while (true)
                            {
                                var buffer = source.Read(bytes);

                                if (buffer == null)
                                {
                                    break;
                                }

                                destination.Write(buffer);

                                read += buffer.Length;

                                Progress = (read*100/total).ToString();
                            }

                            destination.Flush();
                            destination.Close();
                            source.Close();
                        });
                    },
                    () => true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static FileStreamServiceClient CreateClient(string host)
        {
            var binding = new NetTcpBinding (SecurityMode.None)
            {
                MaxReceivedMessageSize = 15728640
            };

            var endpoint = new EndpointAddress(new Uri($"net.tcp://{host}:8000/rFS/FileStreamService"));
            
            return new FileStreamServiceClient(binding, endpoint);
        }
    }
}
