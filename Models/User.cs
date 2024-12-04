using System.ComponentModel.DataAnnotations;
using UserManagementApi.Interfaces;
namespace UserManagementApi.Models
{
        public class User : ISoftDeletable
    {
            public int ID { get; set; }

            [Required(ErrorMessage = "First Name is required")]
            [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
            public required string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required")]
            [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
            public required string LastName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public required string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, contain " +
            "at least one uppercase letter, one lowercase letter, and one number.")]  
        
            public required string Password { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public DateTime? UpdatedAt { get; set; }


            [Phone(ErrorMessage = "Invalid phone number format")]
            public string? Phone { get; set; }

            public string? Address { get; set; }

            //public int SchoolID { get; set; }
            //public required School School { get; set; }

            //public int DepartmentID { get; set; }
            //public required Department Department { get; set; }

            public bool IsActive { get; set; } = true;

            public new bool IsDeleted { get; set; } = false;
            public new DateTime? DeletedAt { get; set; }

            public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
            public ICollection<UserCampus> UserCampuses { get; set; } = new List<UserCampus>();
    }
}



