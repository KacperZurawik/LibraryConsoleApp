﻿using LibraryConsoleApp.Models;
using LibraryConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    internal class Program
    {
        private static LibraryServices libraryServices = new LibraryServices();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Issue book");
                Console.WriteLine("3. Return book");
                Console.WriteLine("4. Show All books");
                Console.WriteLine("5. Search person");
                Console.WriteLine("6. Show registered people");
                Console.WriteLine("7. Exit");

                string menuOptionChoice = Console.ReadLine();
                
                switch (menuOptionChoice)
                {
                    case "1":
                        Console.Clear();
                        libraryServices.AddBook();
                        break;  
                    
                    case "2":
                        Console.Clear();
                        libraryServices.IssueBook();
                        break;

                    case "3":
                        libraryServices.ReturnBook();
                        break;
                        
                    case "4":
                        libraryServices.ShowAllBooks();
                        break;

                    case "5":
                        libraryServices.SearchPerson();
                        break;

                    case "6":
                        libraryServices.ShowUsers();
                        break;

                    case "7":
                        running = false;
                        break;
                }
            }
        }
    }
}
