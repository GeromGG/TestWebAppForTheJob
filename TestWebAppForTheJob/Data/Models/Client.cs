using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Client
    {
        public Client(string inn, string name, bool type)
        {
            Inn = inn;
            Name = name;
            Type = type;
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
        }

        public string Inn { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; } //создать свой класс?!
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }

    }
}
