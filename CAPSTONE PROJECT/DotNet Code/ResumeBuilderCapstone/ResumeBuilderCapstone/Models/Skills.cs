using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(150)]
        public string SkillName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? ProficiencyLevel { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; } 
    }
}
