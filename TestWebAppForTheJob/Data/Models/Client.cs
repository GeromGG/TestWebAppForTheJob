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
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(maximumLength: 12, /*ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.",*/ MinimumLength = 10)]
        [RegularExpression(@"^[0-9]{12}|[0-9]{10}$", ErrorMessage = "ИНН должен состоять из 10 или 12 цифр")]
        [Display(Name = "INN")]
        public string Inn { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZА-Яа-я0-9""'\s-]*$", ErrorMessage = "Введены недопустимые символы")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public bool IsEntrepreneur { get; set; }
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }
        public List<Founder> Founders { get; set; }
    }
}
