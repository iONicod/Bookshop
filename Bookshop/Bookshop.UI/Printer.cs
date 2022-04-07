using Bookshop.Core.Application_Service;
using Bookshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.UI
{
    public class Printer : IPrinter
    {
        private readonly IServiceImpl _serviceImpl;

        public Printer(IServiceImpl serviceImpl)
        {
            _serviceImpl = serviceImpl; 
        }

        public void StartUI()
        {
            string[] menuItems =
            {
                "Показать все книги",
                "Добавить книгу",
                "Удалить книгу",
                "Изменить сведения о книге",
                "Отсортировать книги по цене (от низкой к высокой)",
                "Найти книги по жанру",
                "Показать 5 самых дешевых книг",
                "Выйти из программы"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ListAllBooks();
                        break;
                    case 2:
                        AddBook();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        EditBook();
                        break;
                    case 5:
                        OrderBooksByPrice();
                        break;
                    case 6:
                        SearchForGenre();
                        break;
                    case 7:
                        GetFiveCheapestBooks();
                        break;
                    default:
                        Console.WriteLine("Закрытие программы");
                        break;
                }

                selection = ShowMenu(menuItems);
            }
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Выберите действие:");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Пожалуйста, введите число от 1-7");
            }

            return selection;
        }

        private int PrintFindBookId()
        {
            Console.WriteLine("Введите ID книги: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Пожалуйста, введите ID в числовом формате");
            }
            return id;
        }

        private void ListAllBooks()
        {
            var books = _serviceImpl.GetAllBooks();
            Console.WriteLine("Все книги:");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.id}\n Название: {book.name}\n Язык: {book.language}\n" +
                    $" Автор: {book.author}\n Издательство: {book.publisher}\n Год издания: {book.publishingDate.ToString("yyyy")}\n" +
                    $" Жанр: {book.genre}\n Цена: {book.price}\n");
            }
        }

        private void SearchForGenre()
        {
            Console.WriteLine("Впишите жанр книги");
            var genre = Console.ReadLine().ToLower();
            if (_serviceImpl.SearchForGenre(genre).Count != 0)   
            {
                Console.WriteLine(_serviceImpl.SearchForGenre(genre));
                foreach (var book in _serviceImpl.SearchForGenre(genre))
                {
                    Console.WriteLine($"ID: {book.id} - Название: {book.name} ({book.genre})");
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        private void GetFiveCheapestBooks()
        {
            var books = _serviceImpl.GetFiveCheapestBooks();
            Console.WriteLine("Топ 5 самых дешевых книг");
            int i = 1;
            foreach (var book in books)
            {
                Console.WriteLine($"{i}. Название: {book.name} ({book.id}) - Жанр: {book.genre} - Цена: {book.price}");
                i++;
            }
        }

        private void AddBook()
        {
            var name = AskQuestion("Название:");
            var genre = AskQuestion("Жанр: ");
            var language = AskQuestion("Язык: ");
            var author = AskQuestion("Автор: ");
            var publisher = AskQuestion("Издательство: ");
            
            DateTime publishingDate; Console.WriteLine("Дата издания (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out publishingDate))
            {
                Console.WriteLine("Пожалуйста укажите дату в формате yyyy-mm-dd");
            }            
            double price; Console.WriteLine("Цена: ");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Пожалуйста, укажите значение в нужном формате");
            }

            var newBook = new Book()
            {
                name = name,
                language = language,
                author = author,
                publisher = publisher,
                publishingDate = publishingDate,
                genre = genre,
                price = price
            };

            var book = _serviceImpl.NewBook(newBook);
            _serviceImpl.CreateBook(book);
        }

        private void DeleteBook()
        {
            var idToDelete = PrintFindBookId();
            var deletedBook = _serviceImpl.DeleteBook(idToDelete);
            Console.WriteLine("Вы удалили " + deletedBook.name + " (" + deletedBook.genre + ")" + " c ID " + deletedBook.id);
        }

        private void EditBook()
        {
            var idToEdit = PrintFindBookId();
            var bookToEdit = _serviceImpl.FindBookById(idToEdit);

            Console.WriteLine($"Обновление {bookToEdit.name} ({bookToEdit.genre})");

            var name = AskQuestion("Название:");
            var genre = AskQuestion("Жанр: ");
            var language = AskQuestion("Язык: ");
            var author = AskQuestion("Автор: ");
            var publisher = AskQuestion("Издательство: ");
            
            DateTime publishingDate; Console.WriteLine("Дата издания (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out publishingDate))
            {
                Console.WriteLine("Пожалуйста укажите дату в формате yyyy-mm-dd");
            }            
            double price; Console.WriteLine("Цена: ");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Пожалуйста, укажите значение в нужном формате");
            }

            var newBook = new Book()
            {
                id = idToEdit,
                name = name,
                language = language,
                author = author,
                publisher = publisher,
                publishingDate = publishingDate,
                genre = genre,
                price = price
            };

            _serviceImpl.UpdateBook(newBook);
        }        

        private string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void OrderBooksByPrice()
        {
            var books = _serviceImpl.SortBooksByPrice();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.id}\n Название: {book.name} ({book.genre})\n Цена: {book.price}\n");
            }
        }
    }
}
