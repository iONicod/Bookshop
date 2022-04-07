using Bookshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Core.Application_Service
{
    public interface IServiceImpl
    {
        public Book NewBook(Book book);

        public Book CreateBook(Book book);

        public List<Book> GetAllBooks();

        public Book UpdateBook(Book bookToUpdate);

        public Book DeleteBook(int id);

        public Book FindBookById(int id);

        public List<Book> SortBooksByPrice();

        public List<Book> SearchForGenre(string type);

        public List<Book> GetFiveCheapestBooks();
    }
}
