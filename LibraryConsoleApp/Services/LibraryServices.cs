using LibraryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Services
{
    public class LibraryServices
    {
        private List<Book> books = new List<Book>();
        private List<Book> persons = new List<Book>();


        public void AddBook()
        {
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter book author:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter book description:");
            string description = Console.ReadLine();

            var book = new Book(books.Count + 1, title, author, description);
            books.Add(book);

            Console.WriteLine($"Book '{title}' by {author} added.");
        }
        public void BorrowBook()
        {
            Console.WriteLine("Enter book title:");
           string title = Console.ReadLine();
        }
        public void ReturnBook()
        {
            Console.WriteLine();
        }
        public void ShowAllBooks()
        {
            Console.WriteLine();
        }
    }
}