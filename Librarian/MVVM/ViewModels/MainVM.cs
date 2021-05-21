using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Librarian.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.MVVM.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    class MainVM
    {
        private IMessenger _messenger;

        private string searchKeyword;

        public object CurrentViewModel { get; set; }
        public string SearchKeyword { get => searchKeyword;
            set
            {
                searchKeyword = value;
                if (CurrentViewModel is BooksPageVM)
                {
                    _messenger.Send(new SearchMessage { Content = SearchKeyword });
                }
            }
        }

        #region Commands
        public RelayCommand BooksPageChangeCommand { get; set; }
        public RelayCommand ReadersPageChangeCommand { get; set; }
        #endregion

        public MainVM(IMessenger messenger)
        {
            _messenger = messenger;

            InitalizeCommands();
            RegisterMessenger();
            CurrentViewModel = App.Container.GetInstance<BooksPageVM>();
        }

        private void RegisterMessenger()
        {
            _messenger.Register<NavigationMessage>(this, msg =>
            {
                CurrentViewModel = msg.ViewModel;
            });
        }

        private void InitalizeCommands()
        {
            BooksPageChangeCommand = new RelayCommand(() =>
            {
                if (CurrentViewModel is BooksPageVM == false)
                    CurrentViewModel = App.Container.GetInstance<BooksPageVM>();
            });

            ReadersPageChangeCommand = new RelayCommand(() =>
            {
                if (CurrentViewModel is ReadersPageVM == false)
                    CurrentViewModel = App.Container.GetInstance<ReadersPageVM>();
            });
        }
    }
}
