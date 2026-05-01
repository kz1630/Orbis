using System.ComponentModel.DataAnnotations;

namespace Orbis.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Тип лица обязателен")]
        [StringLength(20)]
        [Display(Name = "Тип лица")]
        public string PersonType { get; set; } // Физическое, Юридическое

        [Required(ErrorMessage = "Наименование обязательно")]
        [StringLength(200)]
        [Display(Name = "Наименование/ФИО")]
        public string Name { get; set; }

        [StringLength(12)]
        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [StringLength(20)]
        [Display(Name = "Серия паспорта")]
        public string? PassportSeries { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер паспорта")]
        public string? PassportNumber { get; set; }

        [StringLength(300)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Phone]
        [StringLength(20)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Contract> Contracts { get; set; }
    }
}
