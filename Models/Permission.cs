using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class Permission: ISoftDeletable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Permission Name is required")]
        [StringLength(50, ErrorMessage = "Permission Name cannot exceed 50 characters")]
        public required string Name { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public new bool IsDeleted { get; set; } 
        public new DateTime? DeletedAt { get; set; }

        public ICollection<RolePermission>? RolePermissions { get; set; } = new List<RolePermission>();
    }
}


