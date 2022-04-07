using Bookshop.Core.Domain_Service;
using Bookshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookshop.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {

        private static List<Book> _books = new List<Book>();
        private static int id = 1;

        public BookRepository()
        {
            InitData();
        }

        public Book CreateBook(Book book)
        {
            book.id = id++;
            _books.Add(book);
            return book;
        }

        public Book DeleteBook(int id)
        {
            var bookToDelete = this.ReadById(id);
            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
                return bookToDelete;
            }
            return null;
        }

        public IEnumerable<Book> ReadAllBooks()
        {
            return _books;
        }

        public Book ReadById(int id)
        {
            foreach (var book in _books)
            {   
                if (book.id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book UpdateBook(Book bookToUpdate)
        {
            var bookFromDB = this.ReadById(bookToUpdate.id);
            if (bookFromDB != null)
            {
                bookFromDB.name = bookToUpdate.name;
                bookFromDB.language = bookToUpdate.language;
                bookFromDB.author = bookToUpdate.author;
                bookFromDB.publisher = bookToUpdate.publisher;
                bookFromDB.publishingDate = bookToUpdate.publishingDate;
                bookFromDB.genre = bookToUpdate.genre;
                bookFromDB.price = bookToUpdate.price;
                return bookFromDB;
            }
            return null;
        }

        private void InitData()
        {
            var book1 = new Book()
            {
                name = "How to Catch the Easter Bunny",
                language = "английский",
                author = "Addam Wallace",
                publisher = "Sourcebooks Wonderland",
                publishingDate = new DateTime(2017, 1, 1),
                genre = "kids literature",
                price = 512
            };
            CreateBook(book1);

            var book2 = new Book()
            {
                name = "Месяц за Рубиконом",
                language = "русский",
                author = "Сергей Лукьяненко",
                publisher = "Издательство АСТ",
                publishingDate = new DateTime(2022, 1, 1),
                genre = "фантастика",
                price = 349
            };
            CreateBook(book2);

            var book3 = new Book()
            {
                name = "Повелитель вселенных",
                language = "русский",
                author = "Юрий Тарарев",
                publisher = "Автор",
                publishingDate = new DateTime(2022, 1, 1),
                genre = "фантастика",
                price = 199
            };
            CreateBook(book3);

            var book4 = new Book()
            {
                name = "How to Catch the Easter Bunny",
                language = "english",
                author = "Addam Wallace",
                publisher = "Sourcebooks Wonderland",
                publishingDate = new DateTime(2017, 1, 1),
                genre = "kids literature",
                price = 512
            };
            CreateBook(book4);

            var book5 = new Book()
            {
                name = "Вижу вас из облаков",
                language = "русский",
                author = "Анна Литвинова",
                publisher = "Эксмо",
                publishingDate = new DateTime(2022, 1, 1),
                genre = "детектив",
                price = 289
            };
            CreateBook(book5);

            var book6 = new Book()
            {
                name = "Will",
                language = "английский",
                author = "Will Smith",
                publisher = "Эксмо",
                publishingDate = new DateTime(2022, 1, 1),
                genre = "биография",
                price = 499
            };
            CreateBook(book6);

            var book7 = new Book()
            {
                name = "Выбор. О свободе и внутренней силе человека",
                language = "русский",
                author = "Эдит Ева Эгер",
                publisher = "МИФ",
                publishingDate = new DateTime(2019, 1, 1),
                genre = "биография",
                price = 499
            };
            CreateBook(book7);
        }
    }
}
