using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Services
{
    public class EducationService
    {
        private readonly ResumeDbContext _db;
        public EducationService(ResumeDbContext db) => _db = db;

        public async Task<Education> CreateAsync(Education item)
        {
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;
            _db.Education.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<Education>> GetByResumeAsync(int resumeId) =>
            await _db.Education.Where(e => e.ResumeId == resumeId).ToListAsync();

        public async Task<Education?> GetAsync(int id) =>
            await _db.Education.FindAsync(id);

        public async Task<bool> UpdateAsync(Education item)
        {
            var existing = await _db.Education.FindAsync(item.EducationId);
            if (existing == null) return false;

            existing.InstitutionName = item.InstitutionName;
            existing.Degree = item.Degree;
            existing.FieldOfStudy = item.FieldOfStudy;
            existing.PercentageOrCGPA = item.PercentageOrCGPA;
            existing.UniversityOrBoard = item.UniversityOrBoard;
            existing.StartDate = item.StartDate;
            existing.EndDate = item.EndDate;
            existing.UpdatedAt = DateTime.Now;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Education.FindAsync(id);
            if (existing == null) return false;

            _db.Education.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
