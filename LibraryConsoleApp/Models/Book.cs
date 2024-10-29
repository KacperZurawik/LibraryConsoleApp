using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsBorrowed { get; set; }

        public Book(int id,string title, string author, string Description)
        {
            Id = id;
            Title = title;
            Author = author;
            IsBorrowed = false;
        }
    }
}
