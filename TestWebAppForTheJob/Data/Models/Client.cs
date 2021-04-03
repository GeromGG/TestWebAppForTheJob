using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Client
    {
        public Client()
        {

        }
        public Client(string inn, string name, bool isEntrepreneur, List<Founder> founder)
        {
            //Id = id;
            Inn = inn;
            Name = name;
            IsEntrepreneur = isEntrepreneur;

            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;

            //Founders = new List<Founder>();
            //Founders.AddRange(founder);
            Founders = new List<Founder>(founder);
        }

        public int Id { get; set; } = 0;
        public string Inn { get; set; }
        public string Name { get; set; }
        public bool IsEntrepreneur { get; set; }  
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }
        public ICollection<Founder> Founders { get; set; }

        //public List<Founder> Founders { get; set; }
    }
}
