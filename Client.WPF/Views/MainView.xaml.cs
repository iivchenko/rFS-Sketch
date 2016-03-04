// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Windows;
using Client.WPF.ViewModels;
using ShogunLib.Events;
using Sketch.FileSystem;
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
            var viewModel = (MainViewModel)DataContext;

            var window = new AgentsView(viewModel.Agets)
            {
                Owner = this
            };

            window.ShowDialog();
        }

        private void MenuExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AgentView_OnCopy(object sender, SimpleEventArgs<string> e)
        {
            var view = (AgentView)sender;
            var viewModel = (MainViewModel) DataContext;

            var source = (AgentViewModel)view.DataContext;
            var destination = view.Orientation == "Left" ? viewModel.Right : viewModel.Left;

            var sourceT = new Tuple<string, FileEntry>(source.ActiveAgent.Host, (FileEntry)source.SelectedEntry);
            var destinationT = new Tuple<string, DirectoryEntry>(destination.ActiveAgent.Host, destination.ActiveDirectory);

            var copyFileViewModel = new CopyFileViewModel(sourceT, destinationT);
            copyFileViewModel.Start.Execute(null);

            var copyWindow = new CopyFileView(copyFileViewModel)
            {
                Owner = this
            };

            copyWindow.ShowDialog();
        }
    }
}
