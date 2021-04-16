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
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(maximumLength: 12, /*ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.",*/ MinimumLength = 10)]
        [RegularExpression(@"^[0-9]{12}|[0-9]{10}$", ErrorMessage = "ИНН должен состоять из 10 или 12 цифр")]
        [Display(Name = "ИНН")]
        public string Inn { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-ZА-Яа-я""'\s-]*$", ErrorMessage = "Введены недопустимые символы")] //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; }
        public virtual Client Client { get; set; }
        public string ClientId { get; set; }
    }
}