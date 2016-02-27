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
        public MainViewModel(IRepository<AgentEntity> repository)
        {
            Agets = new AgentsViewModel(repository);

            Left = new AgentViewModel(repository);
            Right = new AgentViewModel(repository);
        }

        public AgentsViewModel Agets { get; private set; }

        public AgentViewModel Left { get; private set; }

        public AgentViewModel Right { get; private set; }
    }
}
