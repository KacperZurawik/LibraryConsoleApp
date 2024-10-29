using LibraryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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
            Thread.Sleep(3000);
            Console.Clear();
        }
        public void BorrowBook()
        {
           
           string title = Console.ReadLine();
        }
        public void ReturnBook()
        {
            Console.WriteLine();
        }
        public void ShowAllBooks()
        {
            //shows amount of books and their titles
            Console.Clear();
            Console.WriteLine("There are: " + (books.Capacity = books.Count) + "books in library");
            Console.WriteLine(books[0].Title);
            Thread.Sleep(3000);
            Console.Clear();

            Console.WriteLine();
        }
    }
}