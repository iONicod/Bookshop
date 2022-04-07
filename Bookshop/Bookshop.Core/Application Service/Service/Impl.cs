using Bookshop.Core.Domain_Service;
using Bookshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookshop.Core.Application_Service.Service
{
    public class Impl: IServiceImpl
    {
        readonly IBookRepository _bookRepo;

        public Impl(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public Book CreateBook(Book book)
        {
            return _bookRepo.CreateBook(book);
        }

        public Book DeleteBook(int id)
        {
            return _bookRepo.DeleteBook(id);
        }

        public Book FindBookById(int id)
        {
            return _bookRepo.ReadById(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepo.ReadAllBooks().ToList();
        }

        public Book NewBook(Book book)
        {
            var newBook = new Book()
            {
                id = book.id,
                name = book.name,
                language = book.language,
                author = book.author,
                publisher = book.publisher,
                publishingDate = book.publishingDate,
                genre = book.genre,
                price = book.price
            };
            return newBook;            
        }

        public List<Book> SearchForGenre(string genre)
        {
            var allBooks = GetAllBooks();
            var query = allBooks.Where(searchBook => searchBook.genre.ToLower().Equals(genre)).ToList();
            return query;
        }

        public List<Book> SortBooksByPrice()
        {
            var allBooks = GetAllBooks();
            var query = allBooks.OrderBy(book => book.price);
            return query.ToList();
        }

        public List<Book> GetFiveCheapestBooks()
        {
            var allBooksSorted = SortBooksByPrice();
            var query = allBooksSorted.Take(5);
            return query.ToList();
        }

        public Book UpdateBook(Book bookToUpdate)
        {   
            var book = FindBookById(bookToUpdate.id);
            book.name = bookToUpdate.name;
            book.language = bookToUpdate.language;
            book.author = bookToUpdate.author;
            book.publisher = bookToUpdate.publisher;
            book.publishingDate = bookToUpdate.publishingDate;
            book.genre = bookToUpdate.genre;
            book.price = bookToUpdate.price;
            return book;            
        }
    }
}
