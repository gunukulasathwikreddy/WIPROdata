using Microsoft.EntityFrameworkCore;

namespace ResumeBuilderCapstone.Models
{
    public class ResumeDbContext : DbContext
    {
        public ResumeDbContext() { }

        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {
        }

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Resume>().ToTable("Resumes");
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Experience>().ToTable("Experience");
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Certification>().ToTable("Certifications");
            modelBuilder.Entity<Achievement>().ToTable("Achievements");
            modelBuilder.Entity<AISuggestion>().ToTable("AISuggestions");


            modelBuilder.Entity<Resume>()
                .HasOne(r => r.User)
                .WithMany(u => u.Resumes)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Education>()
                .HasOne(e => e.Resume)
                .WithMany(r => r.Education)
                .HasForeignKey(e => e.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Resume)
                .WithMany(r => r.Experience)
                .HasForeignKey(e => e.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Resume)
                .WithMany(r => r.Skills)
                .HasForeignKey(s => s.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Resume)
                .WithMany(r => r.Projects)
                .HasForeignKey(p => p.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Certification>()
                .HasOne(c => c.Resume)
                .WithMany(r => r.Certifications)
                .HasForeignKey(c => c.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Achievement>()
                .HasOne(a => a.Resume)
                .WithMany(r => r.Achievements)
                .HasForeignKey(a => a.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AISuggestion>()
                .HasOne(s => s.Resume)
                .WithMany(r => r.AISuggestions)
                .HasForeignKey(s => s.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; } 
        public DbSet<Certification> Certifications { get; set; } 
        public DbSet<Achievement> Achievements { get; set; } 
        public DbSet<AISuggestion> AISuggestions { get; set; }

    }
}
