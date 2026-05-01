using System.ComponentModel.DataAnnotations;

namespace Orbis.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(50)]
        [Display(Name = "Логин")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Роль обязательна")]
        [StringLength(20)]
        [Display(Name = "Роль")]
        public string Role { get; set; } // Admin, Manager, User

        [StringLength(100)]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
