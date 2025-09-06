using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class SkillService
    {
        private readonly ResumeDbContext _db;
        public SkillService(ResumeDbContext db) => _db = db;

        public async Task<Skill> CreateAsync(Skill item)
        {
            _db.Skills.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<Skill>> GetByResumeAsync(int resumeId) =>
            await _db.Skills.Where(s => s.ResumeId == resumeId).ToListAsync();

        public async Task<Skill?> GetAsync(int id) =>
            await _db.Skills.FindAsync(id);

        public async Task<bool> UpdateAsync(Skill item)
        {
            var existing = await _db.Skills.FindAsync(item.SkillId);
            if (existing == null) return false;

            existing.SkillName = item.SkillName;
            existing.ProficiencyLevel = item.ProficiencyLevel;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Skills.FindAsync(id);
            if (existing == null) return false;

            _db.Skills.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

