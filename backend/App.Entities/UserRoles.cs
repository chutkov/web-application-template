using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    [PrimaryKey(nameof(Id))]
    public class UserRoles
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
        /// Роль
        /// </summary>
        public required Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
    }
}