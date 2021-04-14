using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebAppForTheJob.Data.Models
{
    public class Client
    {
        public Client()
        {
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
            Founders = new List<Founder>();
        }
        public Client(string inn, string name, bool isEntrepreneur, List<Founder> founder)
        {
            Inn = inn;
            Name = name;
            IsEntrepreneur = isEntrepreneur;
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
            Founders = new List<Founder>(founder);
        }

        public int Id { get; set; } = 0;
        [Required]
        [StringLength(12, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 10)]
        [Display(Name = "INN")]
        public string Inn { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public bool IsEntrepreneur { get; set; }
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }
        public List<Founder> Founders { get; set; }
    }
}
