using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    internal class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Person(string name, string lastName, string phoneNumber, string address, string email)
        {
            Name = name;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
