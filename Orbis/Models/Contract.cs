using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orbis.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Номер договора обязателен")]
        [StringLength(50)]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "Дата заключения обязательна")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "Дата начала обязательна")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Дата окончания обязательна")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Сумма договора обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Статус обязателен")]
        [StringLength(50)]
        public string Status { get; set; } // Активный, Завершен, Просрочен, Расторгнут

        [StringLength(500)]
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Required]
        public int InsuranceServiceId { get; set; }
        [ForeignKey("InsuranceServiceId")]
        public InsuranceService InsuranceService { get; set; }

        public int? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public User CreatedByUser { get; set; }
    }
}
