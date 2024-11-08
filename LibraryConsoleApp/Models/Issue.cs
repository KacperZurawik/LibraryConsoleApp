using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    internal class Issue
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public Issue(int issueId, string title, string name)
        {
            IssueId = issueId;
            Title = title;
            Name = name;
        }
    }
}
