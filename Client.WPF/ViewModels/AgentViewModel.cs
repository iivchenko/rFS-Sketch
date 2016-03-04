﻿// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Windows.Input;
using Client.WPF.Common;
using Client.WPF._FileSystemService;
using ShogunLib.Events;
using Sketch.FileSystem;
using IFileSystemService = Client.WPF._FileSystemService.IFileSystemService;

namespace Client.WPF.ViewModels
{
    // TODO: This view model looks like shit - Refactor =)
    public sealed class AgentViewModel : INotifyPropertyChanged, IDisposable
    {
        private AgentEntity _activeAgent;
        private FileSystemEntry _selectedEntry;
        private FileSystemEntry _parentEntry;
        private DirectoryEntry _activeDirectory;

        private readonly AgentsStorage _agentsStorage;
        private readonly IDictionary<string, IFileSystemService> _agents;
        
        public AgentViewModel(AgentsStorage agentsStorage)
        {
            _agentsStorage = agentsStorage;
            _agents = new Dictionary<string, IFileSystemService>();

            _agentsStorage.AgentAdded += Update;
            _agentsStorage.AgentRemoved += Update;
            _agentsStorage.AgentUpdated += Update;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<AgentEntity> Agents
        {
            get { return _agentsStorage.ToList(); }
        }

        public IEnumerable<FileSystemEntry> FileSystemEntires { get; private set; }

        public AgentEntity ActiveAgent
        {
            get
            {
                return _activeAgent;
            }

            set
            {
                _activeAgent = value;

                Connect();

                OnPropertyChanged();
                OnPropertyChanged("FileSystemEntires");
            }
        }

        public FileSystemEntry ParentEntry
        {
            get
            {
                return _parentEntry;
            }

            set
            {
                _parentEntry = value;

                OnPropertyChanged();
            }
        }

        public FileSystemEntry SelectedEntry
        {
            get
            {
                return _selectedEntry;
            }

            set
            {
                _selectedEntry = value;
                
                OnPropertyChanged();
            }
        }

        public DirectoryEntry ActiveDirectory
        {
            get
            {
                return _activeDirectory;
                
            }

            set
            {
                _activeDirectory = value;
                
                OnPropertyChanged();
            }
        }

        public ICommand Apply
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        if (SelectedEntry is DirectoryEntry)
                        {
                            // TODO: Fix the problem when we don't use connection for a long time.
                            var list = _agents[_activeAgent.DisplayName].EnumerateEntries(SelectedEntry.FullName).ToList();

                            if (SelectedEntry.Parent != null && SelectedEntry.FullName != "\\")
                            {
                                var info = new DirectoryInfo(SelectedEntry.Parent);

                                var back = new DirectoryEntry
                                {
                                    Name = "...",
                                    FullName = SelectedEntry.Parent,
                                    Parent = info.Parent?.FullName ?? "\\"
                                };

                                list.Insert(0, back);
                            }

                            FileSystemEntires = list;

                            ActiveDirectory = (DirectoryEntry)SelectedEntry;
                            SelectedEntry = null;

                            OnPropertyChanged("FileSystemEntires");
                        }
                    },
                    () => true);
            }
        }

        public void Dispose()
        {
            _agentsStorage.AgentAdded -= Update;
            _agentsStorage.AgentRemoved -= Update;
            _agentsStorage.AgentUpdated -= Update;
        }

        private void Connect()
        {
            if (!_agents.Keys.Contains(ActiveAgent.DisplayName))
            {
                _agents.Add(ActiveAgent.DisplayName, CreateClient(ActiveAgent.Host));

                FileSystemEntires = _agents[_activeAgent.DisplayName].EnumerateEntries("\\");

                ActiveDirectory = new DirectoryEntry
                {
                    Name = "\\",
                    FullName = "\\",
                    Parent = null
                };
            }
        }

        private FileSystemServiceClient CreateClient(string host)
        {
            var binding = new NetTcpBinding(SecurityMode.None);
            var endpoint = new EndpointAddress(new Uri($"net.tcp://{host}:8000/rFS/FileSystemService"));

            return new FileSystemServiceClient(binding, endpoint);
        }

        private void Update(object sender, SimpleEventArgs<AgentEntity> args)
        {
            OnPropertyChanged("Agents");
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
