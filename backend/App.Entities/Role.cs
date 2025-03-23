using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace App.Entities
{
    /// <summary>
    /// Роль
    /// </summary>
    [PrimaryKey(nameof(Id))]
    public class Role
    {
        public required Guid Id { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        [MaxLength(16)]
        public required string Name { get; set; }
    }
}