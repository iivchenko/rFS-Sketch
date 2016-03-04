// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Client.WPF.Common;
using ShogunLib.Events;

namespace Client.WPF.ViewModels
{
    public sealed class AgentsViewModel : INotifyPropertyChanged, IDisposable
    {
        private string _newAgentName;
        private string _newAgentHost;

        private AgentEntity _selectedAgent;

        private readonly AgentsStorage _agentsStorage;

        public AgentsViewModel(AgentsStorage agentsStorage)
        {
            _agentsStorage = agentsStorage;

            _agentsStorage.AgentAdded += Update;
            _agentsStorage.AgentRemoved += Update;
            _agentsStorage.AgentUpdated += Update;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string NewAgentName
        {
            get
            {
                return _newAgentName;
            }

            set
            {
                _newAgentName = value;

                OnPropertyChanged();
            }
        }

        public string NewAgentHost
        {
            get
            {
                return _newAgentHost;
            }

            set
            {
                _newAgentHost = value;

                OnPropertyChanged();
            }
        }

        public AgentEntity SelectedAgent
        {
            get
            {
                return _selectedAgent;
            }

            set
            {
                _selectedAgent = value;
                
                OnPropertyChanged();
            }
        }

        public IEnumerable<AgentEntity> Agents
        {
            get { return _agentsStorage.ToList(); }
        }

        public ICommand Add
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        var found =
                            _agentsStorage
                                .Find(
                                    x => x.DisplayName.Equals(_newAgentName, StringComparison.OrdinalIgnoreCase) ||
                                         x.Host.Equals(_newAgentHost, StringComparison.OrdinalIgnoreCase))
                                .Any();

                        if (found)
                        {
                            throw new InvalidOperationException("The agent with the same name of host is presedt!");
                        }

                        _agentsStorage.Add(new AgentEntity {Host = _newAgentHost, DisplayName = _newAgentName});
                        
                        NewAgentHost = NewAgentName = string.Empty;

                    },
                    () => !string.IsNullOrWhiteSpace(NewAgentName) && !string.IsNullOrWhiteSpace(NewAgentHost));
            }
        }

        public ICommand Delete
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        _agentsStorage.Remove(_selectedAgent);
                    },
                    () => _selectedAgent != null);
            }
        }

        public void Dispose()
        {
            _agentsStorage.AgentAdded -= Update;
            _agentsStorage.AgentRemoved -= Update;
            _agentsStorage.AgentUpdated -= Update;
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
