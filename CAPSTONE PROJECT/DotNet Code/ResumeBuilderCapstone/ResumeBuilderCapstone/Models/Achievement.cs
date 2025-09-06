using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Achievements")]
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? DateAchieved { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; }
    }
}

