using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Founder
    {
        public Founder() 
        { 

        }
        public Founder(string clientId, string inn, string fullName)
        {
            //Id = id;
            ClientId = clientId;
            Inn = inn;
            FullName = fullName;
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        [Display(Name = "ИНН")]
        public string Inn { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; } 
        public virtual Client Client { get; set; }
        public string ClientId { get; set; }
    }
}
