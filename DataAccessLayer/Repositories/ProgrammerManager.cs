using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProgrammerManager : IProgrammerRepository
    {
        SystemDbContext _dbContext;

        public ProgrammerManager(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ProgrammerProfile Get(string userId)
        {
            return _dbContext.ProgrammerProfiles.Find(userId);
        }

        public IEnumerable<ProgrammerProfile> GetAll()
        {
            return _dbContext.ProgrammerProfiles.ToList();
        }

        public void Create(ProgrammerProfile profile)
        {
            _dbContext.ProgrammerProfiles.Add(profile);
            if (profile.SkillRates != null)
            {
                _dbContext.SkillRates.AddRange(profile.SkillRates);
            }
        }

        public void Update(ProgrammerProfile item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            ProgrammerProfile profile = _dbContext.ProgrammerProfiles.Find(id);
            if (profile != null)
                _dbContext.ProgrammerProfiles.Remove(profile);
            _dbContext.SkillRates.RemoveRange(profile.SkillRates);
        }

        public IEnumerable<ProgrammerProfile> Find(Func<ProgrammerProfile, bool> predicate)
        {
            return _dbContext.ProgrammerProfiles.Where(predicate);
        }

        public void UpdateProgrammerSkillRate(SkillRate skillRate)
        {
            _dbContext.Entry(skillRate).State = EntityState.Modified;
        }

        public void CreateProgrammerSkillRate(SkillRate skillRate)
        {
            _dbContext.SkillRates.Add(skillRate);
            _dbContext.SaveChanges();
        }
    }
}
