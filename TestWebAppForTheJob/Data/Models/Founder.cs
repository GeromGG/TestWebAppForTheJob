using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Founder
    {
        public Founder() 
        { 

        }
        public Founder(int clientId, string inn, string fullName)
        {
            //Id = id;
            ClientId = clientId;
            Inn = inn;
            FullName = fullName;
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Inn { get; set; }
        public string FullName { get; set; }
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; } 
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
