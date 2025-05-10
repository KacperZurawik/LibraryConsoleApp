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
    public class LibraryService
    {
        private List<Book> books = new List<Book>();
        private List<Customer> customers = new List<Customer>();
        private List<Issue> issues = new List<Issue>();
        bool isIssued = false;

        public void AddBook()
        {
            string title;
            do
            {
                Console.Write("Enter book title: \t");
                title = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty!");
                }
            } while (string.IsNullOrWhiteSpace(title));

            string author;
            do
            {
                Console.Write("Enter book author: \t");
                author = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Author cannot be empty!");
                }
            } while (string.IsNullOrWhiteSpace(author));


            string description;
            do
            {
                Console.Write("Enter book description: \t");
                description = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Description cannot be empty!");
                }
            } while (string.IsNullOrWhiteSpace(description));

            var book = new Book(books.Count + 1, title, author, description);
            books.Add(book);

            Console.WriteLine($"Book '{title}' by {author} added.");
            Thread.Sleep(1000);
            Console.Clear();
        }
       
        public void IssueBook() 
        {
            //isCustomerRegistered();

            string title;
            do
            {
                Console.WriteLine("Enter book title: \t");
                title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("title cannot be empty!");
                }
            } while (string.IsNullOrWhiteSpace(title));

            if (books.Any(p => p.Title == title))
            {
                isIssued = true;
                Console.WriteLine($"Issue book: {title}");

                string email;
                do
                {
                    Console.WriteLine("Email: \t");
                    email = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine("Email cannot be empty!");
                    }
                }
                while (string.IsNullOrWhiteSpace(email));

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

            Console.Clear();
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
     
        public void AddCustomer()
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

            var customer = new Customer(customers.Count + 1, name, lastName, address, phoneNumber, email);
            customers.Add(customer);

            Thread.Sleep(5000);
            Console.Clear();
        }
        
        public void SearchCustomer()
        {         
            Console.WriteLine("Enter email: ");

            if (customers.Count == 0)
            {
                Console.WriteLine("There are no customers in the system.");
            }

            if (customers.Count >= 1 ) 
            {
                Console.WriteLine("Enter an address e-mail: ");
                string email = Console.ReadLine();

                if (customers.Any(customer => customer.Email == email))
                {
                    Console.WriteLine(customers);
                    Console.ReadLine();
                }
            }
        }

        public void ShowCustomer()
        {
            Console.Clear();
            Console.WriteLine($"There are {customers.Count} customer in the library management system registered.\n");

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.LastName);
                Console.WriteLine(customer.Address);
                Console.WriteLine(customer.PhoneNumber);
                Console.WriteLine(customer.Email);

                Console.WriteLine(new string('-', 45));
            } 

        }

        // This method checks if the customer is registered in the system. 
        // If not, you can create a new record or find if the customer is already registered.
        public void isCustomerRegistered()
        {
            Console.WriteLine("Is the customer available in the Library system? \nY/N?");
            string isCustomerRegistered = Console.ReadLine();

            if (isCustomerRegistered == "y" || isCustomerRegistered == "Y")
            {
                Console.WriteLine("Enter e-mail address: \t");
                string email = Console.ReadLine();

                if (customers.Any(p => p.Email == email))
                {
                    Console.WriteLine(email);
                }
                else
                {
                    Console.WriteLine("No customers found with the specified email.");
                }
            }

            if (isCustomerRegistered == "n" || isCustomerRegistered == "N")
            {
                AddCustomer();
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

            foreach (var issue in issues)
            {
                Console.WriteLine($"Title: {issue.Title}");

                Console.WriteLine(new string('-', 45));
            }
        }
    
    }
}