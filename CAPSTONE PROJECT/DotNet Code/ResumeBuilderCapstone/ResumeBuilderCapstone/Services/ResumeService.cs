using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class ResumeService
    {
        private readonly ResumeDbContext _db;
        public ResumeService(ResumeDbContext db) => _db = db;

        public async Task<Resume> CreateAsync(Resume resume)
        {
            resume.CreatedAt = DateTime.Now;
            resume.UpdatedAt = DateTime.Now;
            _db.Resumes.Add(resume);
            await _db.SaveChangesAsync();
            return resume;
        }

        public async Task<Resume?> GetByIdAsync(int resumeId) =>
            await _db.Resumes
                .Include(r => r.Education)
                .Include(r => r.Experience)
                .Include(r => r.Skills)
                .Include(r => r.Projects)
                .Include(r => r.Certifications)
                .Include(r => r.Achievements)
                .Include(r => r.AISuggestions)
                .FirstOrDefaultAsync(r => r.ResumeId == resumeId);

        public async Task<List<Resume>> GetByUserAsync(int userId) =>
            await _db.Resumes.Where(r => r.UserId == userId).ToListAsync();

        public async Task<bool> UpdateAsync(Resume resume)
        {
            var existing = await _db.Resumes.FindAsync(resume.ResumeId);
            if (existing == null) return false;

            existing.Title = resume.Title;
            existing.Objective = resume.Objective;
            existing.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int resumeId)
        {
            var existing = await _db.Resumes.FindAsync(resumeId);
            if (existing == null) return false;

            _db.Resumes.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

