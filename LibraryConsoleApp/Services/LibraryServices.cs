using LibraryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryConsoleApp.Services
{
    public class LibraryServices
    {
        private List<Book> books = new List<Book>();
        private List<Person> people = new List<Person>();


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
            Console.WriteLine("Is the person available in the Library system? \n Y/N?");

            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Enter e-mail address: \t");
                string email = null;
            }
            if (Console.ReadLine() == "n")
            {
                AddPerson();
            }
            else
            {
                Console.WriteLine("You must enter 'Y' or 'N'");
            }

        }
        public void ReturnBook()
        {

        }

        public void ShowAllBooks()
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

        public void AddPerson()
        {
            Console.Write("Enter name: \t");
            string name = Console.ReadLine();
            Console.Write("Enter  lastname: \t");
            string lastName = Console.ReadLine();
            Console.Write("Enter address: \t");
            string address = Console.ReadLine();
            Console.Write("Enter phone number: \t");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter e-mail address: \t");
            string email = Console.ReadLine();

            var person = new Person(people.Count + 1, name, lastName, address, phoneNumber, email);
            people.Add(person);
        }
        public void SearchPerson()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("There are no user in the system.");
            }
            else
            {
                Console.WriteLine("Enter an address e-mail: ");
                string email = Console.ReadLine();

                if (email == null)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}