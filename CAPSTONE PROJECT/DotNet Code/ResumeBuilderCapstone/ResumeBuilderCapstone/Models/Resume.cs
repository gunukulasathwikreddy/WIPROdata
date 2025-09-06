using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Resumes")]
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }

        [Required]
        public int UserId { get; set; }   // FK -> Users(UserId)

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Objective { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // DB default ok
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Users? User { get; set; }

        // Navigation
        [JsonIgnore]
        public ICollection<Education> Education { get; set; } = new List<Education>();
        [JsonIgnore]
        public ICollection<Experience> Experience { get; set; } = new List<Experience>();
        [JsonIgnore]
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        [JsonIgnore]
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        [JsonIgnore]
        public ICollection<Certification> Certifications { get; set; } = new List<Certification>();
        [JsonIgnore]
        public ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        [JsonIgnore]
        public ICollection<AISuggestion> AISuggestions { get; set; } = new List<AISuggestion>();
    }
}

