using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("AISuggestions")]
    public class AISuggestion
    {
        [Key]
        public int SuggestionId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(100)]
        public string Section { get; set; } = string.Empty; // e.g., "Objective", "Experience"

        [Required]
        public string SuggestedText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; }
    }
}

