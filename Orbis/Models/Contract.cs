using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orbis.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Номер договора обязателен")]
        [StringLength(50)]
        [Display(Name = "Номер договора")]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "Дата заключения обязательна")]
        [Display(Name = "Дата заключения")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "Дата начала обязательна")]
        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Дата окончания обязательна")]
        [Display(Name = "Дата окончания")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Сумма договора обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Статус обязателен")]
        [StringLength(50)]
        [Display(Name = "Статус")]
        public string Status { get; set; } // Активный, Завершен, Просрочен, Расторгнут

        [StringLength(500)]
        [Display(Name = "Примечания")]
        public string Notes { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Клиент")]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Required]
        [Display(Name = "Услуга")]
        public int InsuranceServiceId { get; set; }
        [ForeignKey("InsuranceServiceId")]
        public InsuranceService InsuranceService { get; set; }

        [Display(Name = "Создал")]
        public int? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public User CreatedByUser { get; set; }
    }
}
