using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class Role : ISoftDeletable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Role Name is required")] 
        [StringLength(50, ErrorMessage = "Role Name cannot exceed 50 characters")]
        public required string Name { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public new bool IsDeleted { get; set; } = false;
        public new DateTime? DeletedAt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
