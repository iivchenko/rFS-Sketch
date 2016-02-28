// <copyright company="XATA">
//      Copyright (c) 2016 by Shogun, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Windows;
using Client.WPF.ViewModels;

namespace Client.WPF.Views
{
    /// <summary>
    /// Interaction logic for CopyFileView.xaml
    /// </summary>
    public partial class CopyFileView : Window
    {
        public CopyFileView(CopyFileViewModel viewMovel)
        {
            InitializeComponent();

            DataContext = viewMovel;
        }
    }
}
