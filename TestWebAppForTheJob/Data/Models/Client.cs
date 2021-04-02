using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Client
    {
        public Client(int id, string inn, string name, bool isEntrepreneur, List<Founder> founder)
        {
            Id = id;
            Inn = inn;
            Name = name;
            IsEntrepreneur = isEntrepreneur;

            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;

            Founders = new List<Founder>();
            Founders.AddRange(founder);
        }

        public int Id { get; set; }
        public string Inn { get; set; }
        public string Name { get; set; }
        public bool IsEntrepreneur { get; set; }  
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }
        public List<Founder> Founders { get; set; }
    }
}
