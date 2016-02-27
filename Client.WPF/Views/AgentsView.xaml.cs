// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Windows;
using Client.WPF.ViewModels;

namespace Client.WPF.Views
{
    /// <summary>
    /// Interaction logic for AgentsView.xaml
    /// </summary>
    public partial class AgentsView : Window
    {
        public AgentsView(AgentsViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
