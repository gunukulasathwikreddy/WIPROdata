using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class AchievementService
    {
        private readonly ResumeDbContext _db;
        public AchievementService(ResumeDbContext db) => _db = db;

        public async Task<Achievement> CreateAsync(Achievement item)
        {
            _db.Achievements.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<Achievement>> GetByResumeAsync(int resumeId) =>
            await _db.Achievements.Where(a => a.ResumeId == resumeId).ToListAsync();

        public async Task<Achievement?> GetAsync(int id) =>
            await _db.Achievements.FindAsync(id);

        public async Task<bool> UpdateAsync(Achievement item)
        {
            var existing = await _db.Achievements.FindAsync(item.AchievementId);
            if (existing == null) return false;

            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.DateAchieved = item.DateAchieved;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Achievements.FindAsync(id);
            if (existing == null) return false;

            _db.Achievements.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
