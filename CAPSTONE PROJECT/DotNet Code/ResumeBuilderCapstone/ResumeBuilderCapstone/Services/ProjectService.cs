using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class ProjectService
    {
        private readonly ResumeDbContext _db;
        public ProjectService(ResumeDbContext db) => _db = db;

        public async Task<Project> CreateAsync(Project item)
        {
            _db.Projects.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<Project>> GetByResumeAsync(int resumeId) =>
            await _db.Projects.Where(p => p.ResumeId == resumeId).ToListAsync();

        public async Task<Project?> GetAsync(int id) =>
            await _db.Projects.FindAsync(id);

        public async Task<bool> UpdateAsync(Project item)
        {
            var existing = await _db.Projects.FindAsync(item.ProjectId);
            if (existing == null) return false;

            existing.ProjectName = item.ProjectName;
            existing.Description = item.Description;
            existing.TechnologiesUsed = item.TechnologiesUsed;
            existing.Link = item.Link;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Projects.FindAsync(id);
            if (existing == null) return false;

            _db.Projects.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

