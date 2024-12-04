using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class UserRole : ISoftDeletable
    {
        [Required]
        public int UserID { get; set; }
        public required User User { get; set; }

        [Required]
        public int RoleID { get; set; }
        public required Role Role { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public new bool IsDeleted { get; set; } = false;
        public new DateTime? DeletedAt { get; set; }
    }
}
