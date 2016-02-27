// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Windows;
using Client.WPF.ViewModels;
using Sketch.Repositories;

namespace Client.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void MenuAgents_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new AgentsView(new AgentsViewModel(new XmlRepository<AgentEntity>("Agents.xml")))
            {
                Owner = this
            };

            window.ShowDialog();
        }

        private void MenuExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
