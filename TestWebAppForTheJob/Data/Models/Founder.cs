using System;
using System.ComponentModel.DataAnnotations;

namespace TestWebAppForTheJob.Data.Models
{
    public class Founder
    {
        public Founder()
        {
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
        }
        public Founder(string clientId, string inn, string fullName)
        {
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