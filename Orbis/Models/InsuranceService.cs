using System.ComponentModel.DataAnnotations;

namespace Orbis.Models
{
    public class InsuranceService
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название услуги обязательно")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Стоимость обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Стоимость должна быть положительной")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Срок действия обязателен")]
        [Range(1, 120, ErrorMessage = "Срок от 1 до 120 месяцев")]
        public int DurationMonths { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Contract> Contracts { get; set; }
    }
}
