using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class RolePermission: ISoftDeletable
    {
        [Required]
        public int PermissionID { get; set; }
        public required Permission Permission { get; set; }

        [Required]
        public int RoleID { get; set; }
        public required Role Role { get; set; }

        // Additional Properties
        public DateTime AssignedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public new bool IsDeleted { get; set; } = false;
        public new DateTime? DeletedAt { get; set; }
    }
}


