using System.ComponentModel.DataAnnotations;

namespace Orbis.Models
{
    public class InsuranceService
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название услуги обязательно")]
        [StringLength(200)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Стоимость обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Стоимость должна быть положительной")]
        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Срок действия обязателен")]
        [Range(1, 120, ErrorMessage = "Срок от 1 до 120 месяцев")]
        [Display(Name = "Срок (мес.)")]
        public int DurationMonths { get; set; }

        [StringLength(100)]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Активна")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Дата создания")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Contract> Contracts { get; set; }
    }
}
