using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [PrimaryKey(nameof(Id))]
    public class User
    {
        public required Guid Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(64)]
        public required string Name { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTime CreateAt { get; set; }

        [InverseProperty(nameof(UserPassword.User))]
        public virtual UserPassword? Password { get; set; }

        [InverseProperty(nameof(UserRoles.User))]
        public virtual ICollection<UserRoles>? Roles { get; set; }

    }
}