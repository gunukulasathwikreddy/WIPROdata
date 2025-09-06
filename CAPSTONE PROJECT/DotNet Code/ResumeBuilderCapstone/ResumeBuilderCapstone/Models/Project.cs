using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(200)]
        public string ProjectName { get; set; } = string.Empty;

        public string? Description { get; set; }

        [StringLength(500)]
        public string? TechnologiesUsed { get; set; }

        [StringLength(500)]
        public string? Link { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; } 
    }
}

