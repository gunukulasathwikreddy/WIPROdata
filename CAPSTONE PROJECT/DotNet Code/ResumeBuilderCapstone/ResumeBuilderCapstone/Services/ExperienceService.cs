using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class ExperienceService
    {
        private readonly ResumeDbContext _db;
        public ExperienceService(ResumeDbContext db) => _db = db;

        public async Task<Experience> CreateAsync(Experience item)
        {
            _db.Experience.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<Experience>> GetByResumeAsync(int resumeId) =>
            await _db.Experience.Where(e => e.ResumeId == resumeId).ToListAsync();

        public async Task<Experience?> GetAsync(int id) =>
            await _db.Experience.FindAsync(id);

        public async Task<bool> UpdateAsync(Experience item)
        {
            var existing = await _db.Experience.FindAsync(item.ExperienceId);
            if (existing == null) return false;

            existing.JobTitle = item.JobTitle;
            existing.Company = item.Company;
            existing.StartDate = item.StartDate;
            existing.EndDate = item.EndDate;
            existing.Description = item.Description;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Experience.FindAsync(id);
            if (existing == null) return false;

            _db.Experience.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
