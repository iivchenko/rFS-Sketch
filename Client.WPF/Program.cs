// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Windows;
using Client.WPF.ViewModels;
using Client.WPF.Views;
using Sketch.Repositories;

namespace Client.WPF
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            app.DispatcherUnhandledException += (sender, eventArgs) =>
            {
                eventArgs.Handled = true;
                MessageBox.Show(eventArgs.Exception.ToString(), "Unhandled ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            };

            app.Run(new MainView(new MainViewModel(new AgentsStorage(new XmlRepository<AgentEntity>("Agents.xml")))));
        }
    }
}
