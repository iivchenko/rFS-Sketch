// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Windows.Controls;
using System.Windows.Input;
using ShogunLib.Events;
using Client.WPF.ViewModels;

namespace Client.WPF.Views
{
    /// <summary>
    /// Interaction logic for AgentView.xaml
    /// </summary>
    public partial class AgentView : UserControl
    {
        public AgentView()
        {
            InitializeComponent();
        }

        public event EventHandler<SimpleEventArgs<string>> Copy;

        public string Orientation { get; set; }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            ((AgentViewModel)DataContext).Apply.Execute(null);
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                Copy.Raise(this, Orientation);
            }
        }
    }
}
