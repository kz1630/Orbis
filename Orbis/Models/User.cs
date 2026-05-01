using System.ComponentModel.DataAnnotations;

namespace Orbis.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Роль обязательна")]
        [StringLength(20)]
        public string Role { get; set; } // Admin, Manager, User

        [StringLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
