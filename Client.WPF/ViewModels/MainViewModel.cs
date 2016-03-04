// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using Sketch.Repositories;

namespace Client.WPF.ViewModels
{
    public sealed class MainViewModel
    {
        public MainViewModel(AgentsStorage agentsStorage)
        {
            Agets = new AgentsViewModel(agentsStorage);

            Left = new AgentViewModel(agentsStorage);
            Right = new AgentViewModel(agentsStorage);

            AgentsStorage = agentsStorage;
        }

        public AgentsStorage AgentsStorage { get; private set; }

        public AgentsViewModel Agets { get; private set; }

        public AgentViewModel Left { get; private set; }

        public AgentViewModel Right { get; private set; }
    }
}
