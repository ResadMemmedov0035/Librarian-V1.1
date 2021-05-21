using EFCoreLibrary.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Librarian.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.MVVM.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    class DetailsPageVM
    {
        private IMessenger _messenger;

        public Book CurrentBook { get; set; }

        public RelayCommand BackHomeCommand { get; set; }

        public DetailsPageVM(IMessenger messenger)
        {
            _messenger = messenger;
            InitalizeCommands();
            RegisterMessenger();
        }

        private void RegisterMessenger()
        {
            _messenger.Register<BookMessage>(this, msg =>
            {
                CurrentBook = msg.Book;
            });
        }

        private void InitalizeCommands()
        {
            BackHomeCommand = new RelayCommand(() =>
            {
                _messenger.Send(new NavigationMessage { ViewModel = App.Container.GetInstance<BooksPageVM>() });
            });
        }
    }
}
