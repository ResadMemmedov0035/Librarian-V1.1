using System;
using System.Windows;

namespace Librarian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Container.GetInstance<MVVM.ViewModels.MainVM>();
        }
    }
}
