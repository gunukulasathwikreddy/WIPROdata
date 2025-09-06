using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResumeBuilderCapstone.Models
{
    [Table("Certifications")]
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required, StringLength(200)]
        public string CertificateName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? IssuedBy { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [StringLength(500)]
        public string? CredentialUrl { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ResumeId))]
        public Resume? Resume { get; set; }
    }
}
