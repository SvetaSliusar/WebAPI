using System;
using System.Threading.Tasks;
using DataAccessLayer.Identity;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get;}
        ApplicationRoleManager RoleManager { get; }
        IRepository<string, ProgrammerProfile> ProgrammerManager { get;}
        IRepository<int, Skill> Skills { get;}
        IRepository<int, SkillCategory> SkillCategories { get; }
        void Save();
        Task SaveAsync();
    }
}
