using LibraryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Services
{
    public class LibraryServices
    {
        private List<Book> books = new List<Book>();
        private List<Book> persons = new List<Book>();


        public void AddBook()
        {
            Console.Write("Enter book title: \t");
            string title = Console.ReadLine();
            Console.Write("Enter book author: \t");
            string author = Console.ReadLine();
            Console.Write("Enter book description: \t");
            string description = Console.ReadLine();

            var book = new Book(books.Count + 1, title, author, description);
            books.Add(book);

            Console.WriteLine($"Book '{title}' by {author} added.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void BorrowBook()
        {
            
            

        }

        public void ReturnBook()
        {

        }

        public void ShowAllBooks()
        {
            Console.Write("Enter book title:\t");
            string title = Console.ReadLine();

            {
                Console.Clear();
                Console.WriteLine($"There are {books.Count} books in the library.\n");

                //shows all books that have been added
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Description: {book.Description}");
                    Console.WriteLine($"Borrow status: {book.IsBorrowed}");

                    //creates space between each books using "-" 30 times
                    Console.WriteLine(new string('-', 35));
                }
            }
        }
    }
}