using System;
using SimpleInjector;
using System.Windows;
using Librarian.MVVM.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using EFCoreLibrary;

namespace Librarian
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            Container.RegisterSingleton<MainVM>();
            Container.RegisterSingleton<BooksPageVM>();
            Container.RegisterSingleton<ReadersPageVM>();
            Container.RegisterSingleton<DetailsPageVM>();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<LibrarianDBContext>();

            var dbContext = Container.GetInstance<LibrarianDBContext>();
            dbContext.Database.EnsureCreated(); // if db doesn't exist then, it create

            base.OnStartup(e);
        }
    }
}
