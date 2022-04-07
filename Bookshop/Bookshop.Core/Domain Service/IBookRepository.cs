using Bookshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Core.Domain_Service
{
    public interface IBookRepository
    {
        public Book CreateBook(Book book);

        public IEnumerable<Book> ReadAllBooks();

        public Book UpdateBook(Book bookToUpdate);

        public Book DeleteBook(int id);

        public Book ReadById(int id);
    }
}
