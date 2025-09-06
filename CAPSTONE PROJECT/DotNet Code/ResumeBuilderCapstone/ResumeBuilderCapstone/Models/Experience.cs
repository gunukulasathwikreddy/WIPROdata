using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Experience")]
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(200)]
        public string JobTitle { get; set; } = string.Empty;

        [Required, StringLength(250)]
        public string Company { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; }
    }
}

