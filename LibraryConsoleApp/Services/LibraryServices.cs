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

        public void IssueBook()
        {
            Console.WriteLine("Is the person available in the Library system? \nY/N?");
            string isPersonRegistered = Console.ReadLine();

            if (isPersonRegistered == "y")
            {
                Console.WriteLine("Enter e-mail address: \t");
                string email = Console.ReadLine();
            }
            if (isPersonRegistered == "n")
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
                Console.WriteLine($"Borrow status: {book.IsIssued}");

                //creates space between each books using "-" 30 times
                Console.WriteLine(new string('-', 45));
            }
        }
        //done yesterday
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

            Console.WriteLine($"{name} {lastName} has been registered. \nMail: {email} \nPhone number: {phoneNumber}");

            var person = new Person(people.Count + 1, name, lastName, address, phoneNumber, email);
            people.Add(person);

            Thread.Sleep(5000);
            Console.Clear();
        }
        //finished here yesterday
        public void SearchPerson()
        {

            Console.WriteLine("Enter email: ");
            if (people.Count == 0)
            {
                Console.WriteLine("There are no user in the system.");
            }
            if (people.Count == 1) 
            {
                Console.WriteLine("Enter an address e-mail: ");
                string email = Console.ReadLine();

                if (people.Any(person => person.Email == email))
                {
                    Console.WriteLine(people);
                    Console.ReadLine();
                }
            }
        }

        public void ShowUsers()
        {
            foreach (var person in people)
            {
                Console.WriteLine(person.Name);
                Console.WriteLine(person.LastName);
                Console.WriteLine(person.Address);
                Console.WriteLine(person.PhoneNumber);
                Console.WriteLine(person.Email);

                Console.WriteLine(new string('-', 45));
            } 
        }
    }
}