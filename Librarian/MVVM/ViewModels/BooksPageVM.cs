using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using EFCoreLibrary;
using EFCoreLibrary.Models;
using GalaSoft.MvvmLight.Messaging;
using Librarian.Messages;

namespace Librarian.MVVM.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    class BooksPageVM
    {
        private IMessenger _messenger;
        private LibrarianDBContext librarianDbContext = App.Container.GetInstance<LibrarianDBContext>();

        private Book selectedBook;

        public List<Book> Books { get; set; }
        public Book SelectedBook { get => selectedBook;
            set
            {
                selectedBook = value;
                _messenger.Send(new BookMessage { Book = SelectedBook });
                _messenger.Send(new NavigationMessage { ViewModel = App.Container.GetInstance<DetailsPageVM>() });
                selectedBook = null;
            }
        }

        public BooksPageVM(IMessenger messenger)
        {
            _messenger = messenger;

            RegisterMessenger();

            Books = librarianDbContext.Books.ToList();
        }

        private void RegisterMessenger()
        {
            _messenger.Register<SearchMessage>(this, msg =>
            {
                var query = from b in librarianDbContext.Books
                            where b.Author.Contains(msg.Content) || b.Title.Contains(msg.Content)
                            select b;
                Books = query.ToList();
            });
        }
    }
}
