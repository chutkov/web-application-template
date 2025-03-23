using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    /// <summary>
    /// Пароль
    /// </summary>
    [PrimaryKey(nameof(Id))]
    public class UserPassword
    {
        public required Guid Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public required Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual User? User { get; set; }

        /// <summary>
        /// Hash пароля SHA-512
        /// </summary>
        [MaxLength(128)]
        public required string Password { get; set; }
    }
}