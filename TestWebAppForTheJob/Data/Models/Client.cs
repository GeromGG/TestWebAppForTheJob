using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Client
    {
        public Client(int id, string inn, string name, bool type, Founder founder)
        {
            Id = id;
            Inn = inn;
            Name = name;
            Type = type;

            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;

            Founders = new List<Founder>();
            Founders.Add(founder);
        }

        public int Id { get; set; }
        public string Inn { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; } //создать свой класс?!
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }
        public List<Founder> Founders { get; set; }
    }
}
