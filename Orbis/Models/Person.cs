using System.ComponentModel.DataAnnotations;

namespace Orbis.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Тип лица обязателен")]
        [StringLength(20)]
        public string PersonType { get; set; } // Физическое, Юридическое

        [Required(ErrorMessage = "Наименование обязательно")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(12)]
        public string INN { get; set; }

        [StringLength(20)]
        public string PassportSeries { get; set; }

        [StringLength(20)]
        public string PassportNumber { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Contract> Contracts { get; set; }
    }
}
