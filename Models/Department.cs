using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;

namespace UserManagementApi.Models
{
    public class Department: ISoftDeletable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100, ErrorMessage = "Department Name cannot exceed 100 characters")]
        public required string Name { get; set; }

        [StringLength(50, ErrorMessage = "Short Name cannot exceed 50 characters")]
        public string? ShortName { get; set; }

        [Required(ErrorMessage = "School is required")]
        public int SchoolID { get; set; }
        public required School School { get; set; }
        

        [Range(0, 100, ErrorMessage = "Attendance Percentage must be between 0 and 100")]
        public int AttendancePercentage { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Allow Attendance After Days must be non-negative")]
        public int AllowAttendanceAfterDays { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Lock Activity Days must be non-negative")]
        public int LockActivityDays { get; set; }

        [StringLength(50, ErrorMessage = "Assessment Method cannot exceed 50 characters")]
        public string? AssessmentMethod { get; set; }

        public bool IsActive { get; set; } = true;

        public bool AllowFacultyAddCLO { get; set; }

        public string? AllowedGPAMethods { get; set; }

        public string? ClearingPersons { get; set; }

        public string? ComplaintReplyingPersons { get; set; }

        public string? Vision { get; set; }

        public string? Signature { get; set; }
        public new bool IsDeleted { get; set; } = false;
        public new DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public required string Type { get; set; } // "Academic" or "Administrative"

        [Required(ErrorMessage = "Default GPA Method is required")]
        public required string DefaultGPAMethod { get; set; } // "Absolute" or "Relative"

    }
}
