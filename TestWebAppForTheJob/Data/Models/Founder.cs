using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Founder
    {
        public Founder(string inn, string fullName)
        {
            Inn = inn;
            FullName = fullName;
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
        }

        public string Inn { get; set; }
        public string FullName { get; set; } //создать свой класс?!
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; } 
    }
}
