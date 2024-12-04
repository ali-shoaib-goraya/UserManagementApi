using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class School: ISoftDeletable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "School Name is required")]
        [StringLength(100, ErrorMessage = "School Name cannot exceed 100 characters")]
        public required string Name { get; set; }

        [StringLength(50, ErrorMessage = "Short Name cannot exceed 50 characters")]
        public string? ShortName { get; set; }

        public string? Address { get; set; }

        public bool Academic { get; set; } = true;

        [Required(ErrorMessage = "Campus ID is required")]
        public int CampusID { get; set; }
        public required Campus Campus { get; set; }

        public string? City { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public new bool IsDeleted { get; set; } = false;
        public new DateTime? DeletedAt { get; set; }

        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}

