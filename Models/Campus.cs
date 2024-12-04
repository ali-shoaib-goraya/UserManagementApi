
using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class Campus: ISoftDeletable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campus Name is required")]
        [StringLength(100, ErrorMessage = "Campus Name cannot exceed 100 characters")]
        public required string Name { get; set; }

        [StringLength(50, ErrorMessage = "Short Name cannot exceed 50 characters")]
        public string? ShortName { get; set; }

        public string? Address { get; set; }

        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string? City { get; set; }

        public string? Notes { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public required string Type { get; set; } // "Main Campus" or "Sub Campus"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public new bool IsDeleted { get; set; } = false;
        public new DateTime? DeletedAt { get; set; }
        public ICollection<School>? Schools { get; set; } = new List<School>();
    }
}
