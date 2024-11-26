using LibraryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
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
        private List<Issue> issues = new List<Issue>();
        bool isIssued = false;

        public interface ISearch
        {

        }

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
            //IsPersonRegistered();

            Console.WriteLine("Enter book title: \t");
            string title = Console.ReadLine();
             
            if (books.Any(p => p.Title == title))
            {
                isIssued = true;
                Console.WriteLine($"Issue book: {title}");
                Console.WriteLine("Email: \t");
                string email = Console.ReadLine();

                Console.WriteLine($"Issue {title} for {email}");

                var issue = new Issue(issues.Count + 1, title, email);
                issues.Add(issue);
                var IssuedAt = DateTime.Now;

                Console.WriteLine($"Issue date: { IssuedAt}");

                Thread.Sleep(1000);
            }

            if (books.Count == 0)
            {
                Console.WriteLine("There are no books in the system");
            }
        }
        //Finished here
        public void ReturnBook()
        {
            if (issues.Count == 0 )
            {
                Console.WriteLine("There are no issues currently");
            }

            Console.WriteLine("Enter title: \t");
            string title = Console.ReadLine();

            if (books.Any(p => p.Title == title))
            {
                IsPersonRegistered();
            }
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
        //Investigate duplicated functionality in the IssueBook method
        public void SearchPerson()
        {         
            Console.WriteLine("Enter email: ");

            if (people.Count == 0)
            {
                Console.WriteLine("There are no user in the system.");
            }

            if (people.Count >= 1 ) 
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
            Console.Clear();
            Console.WriteLine($"There are {people.Count} people in the library management system registered.\n");

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

        // This method checks if the person is registered in the system. 
        // If not, you can create a new record or find if the person is already registered.
        public void IsPersonRegistered()
        {
            Console.WriteLine("Is the person available in the Library system? \nY/N?");
            string isPersonRegistered = Console.ReadLine();

            if (isPersonRegistered == "y" || isPersonRegistered == "Y")
            {
                Console.WriteLine("Enter e-mail address: \t");
                string email = Console.ReadLine();

                if (people.Any(p => p.Email == email))
                {
                    Console.WriteLine(email);
                }
                else
                {
                    Console.WriteLine("No user found with the specified email.");
                }
            }

            if (isPersonRegistered == "n" || isPersonRegistered == "N")
            {
                AddPerson();
            }

            else
            {
                Console.WriteLine("You must enter 'Y' or 'N'");
            }
        }
        public void ShowIssuesList()
        {
            Console.Clear();
            Console.WriteLine($"There are {issues.Count} issues registered.\n");

            //shows all books that have been added
            foreach (var issue in issues)
            {
                Console.WriteLine($"Title: {issue.Title}");

                //creates space between each books using "-" 30 times
                Console.WriteLine(new string('-', 45));
            }
        }
    
    }
}