using DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataAccessLayer.EF
{
    public class SystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public SystemDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ProgrammerProfile> ProgrammerProfiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillRate> SkillRates { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
    }
}
