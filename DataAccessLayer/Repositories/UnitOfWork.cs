using System;
using System.Threading.Tasks;
using DataAccessLayer.EF;
using DataAccessLayer.Identity;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        SystemDbContext _dbContext;

        ApplicationUserManager _userManager;
        ApplicationRoleManager _roleManager;

        IRepository<string, ProgrammerProfile> _programmerProfiles;
        IRepository<int, Skill> _skills;
        IRepository<int, SkillCategory> _skillCategories;
        
        public UnitOfWork(string connectionString)
        {
            _dbContext = new SystemDbContext(connectionString);            
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_dbContext));
                return _userManager;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (_roleManager==null)
                    _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_dbContext));
                return _roleManager;
            }
        }
        public IRepository<string, ProgrammerProfile> ProgrammerManager
        {
            get
            {
                if (_programmerProfiles == null)
                    _programmerProfiles = new ProgrammerManager(_dbContext);
                return _programmerProfiles;
            }
        }

        public IRepository<int, Skill> Skills
        {
            get
            {
                if (_skills == null)
                    _skills = new SkillRepository(_dbContext);
                return _skills;
            }
        }

        public IRepository<int, SkillCategory> SkillCategories
        {
            get
            {
                if (_skillCategories == null)
                    _skillCategories = new CategoryRepository(_dbContext);
                return _skillCategories;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
