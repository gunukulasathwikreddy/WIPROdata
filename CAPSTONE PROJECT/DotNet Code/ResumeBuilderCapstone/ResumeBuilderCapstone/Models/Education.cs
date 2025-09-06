using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Education")]
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(200)]
        public string InstitutionName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Degree { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Required]
        public decimal PercentageOrCGPA { get; set; }   // DECIMAL(5,2)

        [Required, StringLength(150)]
        public string UniversityOrBoard { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; }
    }
}

