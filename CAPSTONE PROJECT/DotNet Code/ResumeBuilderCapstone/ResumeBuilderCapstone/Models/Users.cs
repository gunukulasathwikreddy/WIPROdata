using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }


        [Required, StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; } = string.Empty;


        [Required, StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required, StringLength(255)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*(),.?""':{}|<>]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long\n" +
            "contain one uppercase, one lowercase, one number, and one special character.")]
        public string Password { get; set; } = string.Empty;


        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required, StringLength(10)]
        [RegularExpression("^(?i)(Male|Female)$", ErrorMessage = "Gender must be Male or Female")]
        public string Gender { get; set; } = string.Empty;


        [Required, StringLength(255)]
        public string Address { get; set; } = string.Empty;


        [Required, StringLength(20)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string PhoneNumber { get; set; } = string.Empty;


        [StringLength(100)]
        public string? City { get; set; }


        [Required, StringLength(100)]
        public string State { get; set; } = string.Empty;


        [Required, StringLength(10)]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be exactly 6 digits")]
        public string Pincode { get; set; } = string.Empty;


        [Required, StringLength(50)]
        public string Country { get; set; } = string.Empty;


        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();
    }
}
