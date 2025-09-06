using Microsoft.EntityFrameworkCore;
using ResumeBuilderCapstone.Models;
using System.Text.RegularExpressions;

namespace ResumeBuilderCapstone.Services
{
    public class AISuggestionService
    {
        private readonly ResumeDbContext _db;
        public AISuggestionService(ResumeDbContext db) => _db = db;

        // ========= Public API =========

        public async Task<List<AISuggestion>> GenerateSuggestionsAsync(int resumeId, bool clearOld = true)
        {
            var resume = await _db.Resumes
                .Include(r => r.User)
                .Include(r => r.Education)
                .Include(r => r.Experience)
                .Include(r => r.Skills)
                .Include(r => r.Projects)
                .Include(r => r.Certifications)
                .Include(r => r.Achievements)
                .FirstOrDefaultAsync(r => r.ResumeId == resumeId);

            if (resume == null) return new List<AISuggestion>();

            if (clearOld)
            {
                var old = _db.AISuggestions.Where(s => s.ResumeId == resumeId);
                _db.AISuggestions.RemoveRange(old);
                await _db.SaveChangesAsync();
            }

            var bag = new List<AISuggestion>();

            AnalyzeObjective(resume, bag);
            AnalyzeSkills(resume, bag);
            AnalyzeExperience(resume, bag);
            AnalyzeProjects(resume, bag);
            AnalyzeEducation(resume, bag);
            AnalyzeCertifications(resume, bag);
            AnalyzeAchievements(resume, bag);
            AnalyzeConsistency(resume, bag);
            AnalyzeATS(resume, bag);
            AnalyzeLengthAndDensity(resume, bag);

            // Persist
            if (bag.Count > 0)
            {
                _db.AISuggestions.AddRange(bag);
                await _db.SaveChangesAsync();
            }

            return bag;
        }

        public async Task<List<AISuggestion>> GetByResumeAsync(int resumeId) =>
            await _db.AISuggestions
                .Where(s => s.ResumeId == resumeId)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

        public async Task<AISuggestion?> GetAsync(int id) =>
            await _db.AISuggestions.FindAsync(id);

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.AISuggestions.FindAsync(id);
            if (existing == null) return false;
            _db.AISuggestions.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        // ========= Heuristic “AI” =========

        private static readonly string[] StrongActionVerbs =
        {
            "Led","Owned","Built","Shipped","Designed","Developed","Implemented","Automated",
            "Optimized","Scaled","Refactored","Improved","Reduced","Increased","Migrated",
            "Launched","Orchestrated","Deployed","Integrated","Resolved","Delivered"
        };

        private static readonly string[] WeakPhrases =
        {
            "responsible for","worked on","involved in","tasked with","helped with",
            "participated in","assisted with"
        };

        private static readonly string[] StaleTech =
        {
            "VB6","Flash","Silverlight","Backbone.js","AngularJS","SOAP only","WCF only"
        };

        private static readonly string[] HighValueTech =
        {
            ".NET 6",".NET 7",".NET 8","ASP.NET Core","EF Core","LINQ","C# 10","C# 11",
            "Azure","AWS","Docker","Kubernetes","REST","gRPC","PostgreSQL","SQL Server",
            "Redis","RabbitMQ","CI/CD","GitHub Actions","GitLab CI","Terraform","React","Angular","Vue"
        };

        private static bool HasAny(string text, IEnumerable<string> words) =>
            !string.IsNullOrWhiteSpace(text) && words.Any(w => Regex.IsMatch(text, @"\b" + Regex.Escape(w) + @"\b", RegexOptions.IgnoreCase));

        private static bool LacksAny(string? text, IEnumerable<string> words) =>
            string.IsNullOrWhiteSpace(text) || !words.Any(w => Regex.IsMatch(text, @"\b" + Regex.Escape(w) + @"\b", RegexOptions.IgnoreCase));

        private static bool ContainsUrl(string? text) =>
            !string.IsNullOrWhiteSpace(text) && Regex.IsMatch(text, @"https?://", RegexOptions.IgnoreCase);

        private static int CountDigits(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            return Regex.Matches(text, @"\d").Count;
        }

        private static void Add(List<AISuggestion> bag, int resumeId, string section, string text)
        {
            bag.Add(new AISuggestion
            {
                ResumeId = resumeId,
                Section = section,
                SuggestedText = text.Trim(),
                CreatedAt = DateTime.Now
            });
        }

        // ========= Section Analyzers =========

        private void AnalyzeObjective(Resume r, List<AISuggestion> bag)
        {
            var obj = r.Objective ?? "";
            if (string.IsNullOrWhiteSpace(obj))
            {
                Add(bag, r.ResumeId, "Objective", "Add a concise 2–3 sentence summary highlighting your role, experience level, top skills, and impact.");
                return;
            }

            if (obj.Length < 60) Add(bag, r.ResumeId, "Objective", "Expand your summary to ~60–120 characters; mention domain, experience level, and top 2–3 skills.");
            if (obj.Length > 400) Add(bag, r.ResumeId, "Objective", "Your summary is long. Trim to 2–3 sentences focused on impact and core strengths.");

            if (LacksAny(obj, StrongActionVerbs))
                Add(bag, r.ResumeId, "Objective", "Use strong action verbs (e.g., Developed, Optimized, Led) to emphasize outcomes.");

            if (!HasAny(obj, HighValueTech) && r.Skills.Any())
                Add(bag, r.ResumeId, "Objective", "Mention 1–2 standout technologies (e.g., ASP.NET Core, EF Core, Azure) to boost ATS relevance.");

            if (!obj.Contains("%") && CountDigits(obj) == 0)
                Add(bag, r.ResumeId, "Objective", "Quantify one achievement (e.g., “reduced API latency by 30%”) to show measurable impact.");
        }

        private void AnalyzeSkills(Resume r, List<AISuggestion> bag)
        {
            var skills = r.Skills?.ToList() ?? new List<Skill>();
            if (skills.Count == 0)
            {
                Add(bag, r.ResumeId, "Skills", "Add 8–12 well-chosen skills: back-end (.NET, EF Core), front-end (React/Angular), cloud (Azure), DB (SQL Server), tools (Git, Docker).");
                return;
            }

            if (skills.Count < 5) Add(bag, r.ResumeId, "Skills", "Add more skills (aim 8–12). Include a mix of backend, frontend, DB, cloud, tooling, and soft skills.");
            if (skills.Count > 20) Add(bag, r.ResumeId, "Skills", "Your skills list is long. Keep 10–15 most relevant for the role to avoid noise.");

            var dupes = skills.GroupBy(s => (s.SkillName ?? "").Trim().ToLower())
                              .Where(g => g.Key != "" && g.Count() > 1)
                              .Select(g => g.First().SkillName)
                              .ToList();
            if (dupes.Any()) Add(bag, r.ResumeId, "Skills", $"Remove duplicate skills: {string.Join(", ", dupes)}.");

            if (!skills.Any(s => HighValueTech.Any(h => s.SkillName.Contains(h, StringComparison.OrdinalIgnoreCase))))
                Add(bag, r.ResumeId, "Skills", "Consider adding in-demand items (e.g., ASP.NET Core, EF Core, Azure, Docker, CI/CD).");

            if (skills.Any(s => StaleTech.Any(t => s.SkillName.Contains(t, StringComparison.OrdinalIgnoreCase))))
                Add(bag, r.ResumeId, "Skills", "Replace outdated tech with modern stacks (e.g., .NET 8, ASP.NET Core, React, Docker).");

            // Proficiency presence (optional)
            if (skills.Any(s => string.IsNullOrWhiteSpace(s.ProficiencyLevel)))
                Add(bag, r.ResumeId, "Skills", "Add proficiency levels (Beginner/Intermediate/Advanced) for 3–5 key skills.");
        }

        private void AnalyzeExperience(Resume r, List<AISuggestion> bag)
        {
            var exps = r.Experience?.OrderBy(e => e.StartDate).ToList() ?? new List<Experience>();
            if (exps.Count == 0)
            {
                Add(bag, r.ResumeId, "Experience", "Add internships, freelance, or project-based roles. For freshers, convert major projects into ‘Experience’ with responsibilities.");
                return;
            }

            // Gaps between experiences (>6 months)
            for (int i = 1; i < exps.Count; i++)
            {
                var prevEnd = exps[i - 1].EndDate ?? DateTime.Now;
                var gapMonths = ((exps[i].StartDate.Year - prevEnd.Year) * 12) + exps[i].StartDate.Month - prevEnd.Month;
                if (gapMonths > 6)
                    Add(bag, r.ResumeId, "Experience", $"Explain the {gapMonths}-month gap between roles around {prevEnd:MMM yyyy}–{exps[i].StartDate:MMM yyyy} (e.g., upskilling, certification).");
            }

            foreach (var e in exps)
            {
                var desc = e.Description ?? "";
                if (string.IsNullOrWhiteSpace(desc))
                {
                    Add(bag, r.ResumeId, "Experience", $"Add 3–5 bullet points for '{e.JobTitle}' at {e.Company}, focusing on responsibilities and impact.");
                    continue;
                }

                if (desc.Length < 60)
                    Add(bag, r.ResumeId, "Experience", $"Expand the description for '{e.JobTitle}' at {e.Company}. Mention problems solved, stack used, and business outcome.");

                if (LacksAny(desc, StrongActionVerbs))
                    Add(bag, r.ResumeId, "Experience", $"Start bullets with strong verbs for '{e.JobTitle}' at {e.Company} (Developed, Optimized, Automated…).");

                if (!desc.Contains("%") && CountDigits(desc) < 2)
                    Add(bag, r.ResumeId, "Experience", $"Quantify results for '{e.JobTitle}' at {e.Company} (e.g., -25% latency, +15% throughput, 3x reliability).");

                if (!HasAny(desc, HighValueTech) && r.Skills.Any())
                    Add(bag, r.ResumeId, "Experience", $"Reference key technologies used in '{e.JobTitle}' at {e.Company} (e.g., ASP.NET Core, EF Core, Azure, Docker).");
            }
        }

        private void AnalyzeProjects(Resume r, List<AISuggestion> bag)
        {
            var projects = r.Projects?.ToList() ?? new List<Project>();
            if (projects.Count == 0)
            {
                Add(bag, r.ResumeId, "Projects", "Add 2–4 projects with one-line problem statement, your contribution, tech stack, and outcomes. Include GitHub/demo links.");
                return;
            }

            foreach (var p in projects)
            {
                if (string.IsNullOrWhiteSpace(p.Description))
                    Add(bag, r.ResumeId, "Projects", $"Add a concise description for '{p.ProjectName}' explaining the problem and your impact.");
                if (string.IsNullOrWhiteSpace(p.TechnologiesUsed))
                    Add(bag, r.ResumeId, "Projects", $"List technologies for '{p.ProjectName}' (e.g., ASP.NET Core, EF Core, SQL Server, Azure).");
                if (string.IsNullOrWhiteSpace(p.Link))
                    Add(bag, r.ResumeId, "Projects", $"Provide a GitHub/portfolio link for '{p.ProjectName}' to showcase code or demo.");
                if (!ContainsUrl(p.Description) && !ContainsUrl(p.Link))
                    Add(bag, r.ResumeId, "Projects", $"Add a URL in '{p.ProjectName}' (repo, live demo, or case study) to build credibility.");
                if (LacksAny(p.Description, StrongActionVerbs))
                    Add(bag, r.ResumeId, "Projects", $"Use action verbs in '{p.ProjectName}' to describe what you built and how it helped.");
                if (!p.Description?.Contains("%") ?? true)
                    Add(bag, r.ResumeId, "Projects", $"Quantify the value of '{p.ProjectName}' (e.g., 30% faster build, 2x throughput).");
            }
        }

        private void AnalyzeEducation(Resume r, List<AISuggestion> bag)
        {
            var edus = r.Education?.OrderByDescending(e => e.EndDate ?? DateTime.Now).ToList() ?? new List<Education>();
            if (edus.Count == 0)
            {
                Add(bag, r.ResumeId, "Education", "Add your education with Institution, Degree, Field of Study, Board/University, Start–End dates, and CGPA/Percentage.");
                return;
            }

            foreach (var e in edus)
            {
                if (e.StartDate == default)
                    Add(bag, r.ResumeId, "Education", $"Provide a start date for {e.Degree} at {e.InstitutionName}.");
                if (e.EndDate == null)
                    Add(bag, r.ResumeId, "Education", $"If {e.Degree} at {e.InstitutionName} is ongoing, mark EndDate as null and add “Present/Current” in UI.");
                if (e.PercentageOrCGPA <= 0 || e.PercentageOrCGPA > 100)
                    Add(bag, r.ResumeId, "Education", $"Verify CGPA/Percentage for {e.Degree} at {e.InstitutionName}. Use valid numeric values (e.g., 8.2 CGPA or 78%).");
            }

            // Overlap sanity: overlapping degrees?
            if (edus.Count > 1)
            {
                for (int i = 0; i < edus.Count - 1; i++)
                {
                    var a = edus[i];
                    var b = edus[i + 1];
                    if ((a.EndDate ?? DateTime.Now) < a.StartDate)
                        Add(bag, r.ResumeId, "Education", $"Dates look inverted for {a.Degree} at {a.InstitutionName}. Check Start/End dates.");
                    if (a.StartDate < (b.EndDate ?? DateTime.Now) && (a.EndDate ?? DateTime.Now) > b.StartDate)
                        Add(bag, r.ResumeId, "Education", $"Education entries '{a.Degree}' and '{b.Degree}' overlap. Ensure this is intended or clarify timelines.");
                }
            }
        }

        private void AnalyzeCertifications(Resume r, List<AISuggestion> bag)
        {
            var certs = r.Certifications?.ToList() ?? new List<Certification>();
            if (certs.Count == 0)
            {
                Add(bag, r.ResumeId, "Certifications", "Add role-relevant certifications (e.g., AZ-900, AZ-204, DP-203, AWS CCP) with issue date and credential URL.");
                return;
            }

            foreach (var c in certs)
            {
                if (c.ExpiryDate.HasValue && c.ExpiryDate.Value.Date < DateTime.UtcNow.Date)
                    Add(bag, r.ResumeId, "Certifications", $"“{c.CertificateName}” appears expired. Renew or replace with a current certificate.");
                if (string.IsNullOrWhiteSpace(c.CredentialUrl))
                    Add(bag, r.ResumeId, "Certifications", $"Add credential URL for “{c.CertificateName}” for easy verification.");
                if (!c.IssueDate.HasValue)
                    Add(bag, r.ResumeId, "Certifications", $"Provide issue date for “{c.CertificateName}”.");
            }
        }

        private void AnalyzeAchievements(Resume r, List<AISuggestion> bag)
        {
            var ach = r.Achievements?.ToList() ?? new List<Achievement>();
            if (ach.Count == 0)
            {
                Add(bag, r.ResumeId, "Achievements", "Include 2–3 notable achievements (hackathons, publications, scholarships, rankings).");
                return;
            }

            foreach (var a in ach)
            {
                if (string.IsNullOrWhiteSpace(a.Description))
                    Add(bag, r.ResumeId, "Achievements", $"Add a one-line description to “{a.Title}” explaining scope, scale, or ranking.");
                if (!a.DateAchieved.HasValue)
                    Add(bag, r.ResumeId, "Achievements", $"Add the date for “{a.Title}” to establish recency.");
            }
        }

        private void AnalyzeConsistency(Resume r, List<AISuggestion> bag)
        {
            // Cross-checks across sections
            var hasBackend = r.Skills.Any(s => Regex.IsMatch(s.SkillName ?? "", @"\.NET|C#|EF Core|ASP\.NET", RegexOptions.IgnoreCase));
            var hasProjectBackend = r.Projects.Any(p => Regex.IsMatch((p.TechnologiesUsed ?? "") + " " + (p.Description ?? ""), @"\.NET|C#|EF Core|ASP\.NET", RegexOptions.IgnoreCase));

            if (hasBackend && !hasProjectBackend)
                Add(bag, r.ResumeId, "Consistency", "You list .NET/C# skills but projects don’t reflect them. Add or update project details to align with skills.");

            var hasCloudSkill = r.Skills.Any(s => Regex.IsMatch(s.SkillName ?? "", @"Azure|AWS|GCP", RegexOptions.IgnoreCase));
            var hasCloudMention = r.Experience.Any(e => Regex.IsMatch(e.Description ?? "", @"Azure|AWS|GCP", RegexOptions.IgnoreCase)) ||
                                  r.Projects.Any(p => Regex.IsMatch((p.TechnologiesUsed ?? "") + " " + (p.Description ?? ""), @"Azure|AWS|GCP", RegexOptions.IgnoreCase));
            if (hasCloudSkill && !hasCloudMention)
                Add(bag, r.ResumeId, "Consistency", "Cloud skills are listed but not demonstrated. Add a cloud-related project or bullet (e.g., Azure Web App, AWS Lambda).");

            // Weak phrasing
            foreach (var e in r.Experience)
            {
                if (HasAny(e.Description ?? "", WeakPhrases))
                    Add(bag, r.ResumeId, "Experience", $"Avoid weak phrasing in '{e.JobTitle}' at {e.Company} (e.g., “responsible for”). Start with action verbs and outcomes.");
            }

            // Titles sanity: JobTitle casing
            foreach (var e in r.Experience)
            {
                if (!string.IsNullOrWhiteSpace(e.JobTitle) && e.JobTitle == e.JobTitle.ToLower())
                    Add(bag, r.ResumeId, "Experience", $"Capitalize job titles properly (e.g., “Software Engineer”, not “software engineer”).");
            }
        }

        private void AnalyzeATS(Resume r, List<AISuggestion> bag)
        {
            // ATS hints
            Add(bag, r.ResumeId, "ATS", "Use simple section headings (Summary, Skills, Experience, Projects, Education, Certifications, Achievements) for ATS parsing.");
            Add(bag, r.ResumeId, "ATS", "Avoid text boxes, tables, or images for core content. Use clean bullet points and standard fonts.");
            Add(bag, r.ResumeId, "ATS", "Mirror keywords from the job description (e.g., “ASP.NET Core”, “REST APIs”, “Azure Functions”) where relevant.");
        }

        private void AnalyzeLengthAndDensity(Resume r, List<AISuggestion> bag)
        {
            // A rough density check based on counts
            int bullets =
                (r.Experience?.Count ?? 0) * 3 +
                (r.Projects?.Count ?? 0) * 2 +
                (r.Skills?.Count ?? 0) / 2 +
                (r.Achievements?.Count ?? 0);

            if ((r.Experience?.Count ?? 0) == 0 && (r.Projects?.Count ?? 0) <= 1)
                Add(bag, r.ResumeId, "General", "If you’re early career, prioritize projects and internships to reach a 1-page, impact-focused resume.");

            if (bullets < 8)
                Add(bag, r.ResumeId, "General", "Add more bullet points across Experience/Projects to better demonstrate scope and impact (aim 12–20 bullets total).");

            if (bullets > 35)
                Add(bag, r.ResumeId, "General", "Too many bullets can overwhelm. Keep high-impact points and remove less relevant items.");
        }
    }
}
