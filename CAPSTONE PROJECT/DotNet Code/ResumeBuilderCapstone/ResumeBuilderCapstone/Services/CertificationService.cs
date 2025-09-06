using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class CertificationService
    {
        private readonly ResumeDbContext _db;
        public CertificationService(ResumeDbContext db) => _db = db;

        public async Task<Certification> CreateAsync(Certification item)
        {
            _db.Certifications.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<Certification>> GetByResumeAsync(int resumeId) =>
            await _db.Certifications.Where(c => c.ResumeId == resumeId).ToListAsync();

        public async Task<Certification?> GetAsync(int id) =>
            await _db.Certifications.FindAsync(id);

        public async Task<bool> UpdateAsync(Certification item)
        {
            var existing = await _db.Certifications.FindAsync(item.CertificationId);
            if (existing == null) return false;

            existing.CertificateName = item.CertificateName;
            existing.IssuedBy = item.IssuedBy;
            existing.IssueDate = item.IssueDate;
            existing.ExpiryDate = item.ExpiryDate;
            existing.CredentialUrl = item.CredentialUrl;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Certifications.FindAsync(id);
            if (existing == null) return false;

            _db.Certifications.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

