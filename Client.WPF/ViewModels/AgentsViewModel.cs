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
using Sketch.Repositories;

namespace Client.WPF.ViewModels
{
    public sealed class AgentsViewModel : INotifyPropertyChanged
    {
        private string _newAgentName;
        private string _newAgentHost;

        private AgentEntity _selectedAgent;

        private readonly IRepository<AgentEntity> _repository;

        public AgentsViewModel(IRepository<AgentEntity> repository)
        {
            _repository = repository;
        }

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
            get { return _repository.ToList(); }
        }

        public ICommand Add
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        var found =
                            _repository
                                .Find(
                                    x => x.DisplayName.Equals(_newAgentName, StringComparison.OrdinalIgnoreCase) ||
                                         x.Host.Equals(_newAgentHost, StringComparison.OrdinalIgnoreCase))
                                .Any();

                        if (found)
                        {
                            throw new InvalidOperationException("The agent with the same name of host is presedt!");
                        }

                        _repository.Add(new AgentEntity {Host = _newAgentHost, DisplayName = _newAgentName});

                        OnPropertyChanged("Agents");
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
                        _repository.Remove(_selectedAgent);

                        OnPropertyChanged("Agents");
                    },
                    () => _selectedAgent != null);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
