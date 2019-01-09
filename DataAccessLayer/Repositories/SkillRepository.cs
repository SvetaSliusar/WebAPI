using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    class SkillRepository : IRepository<int, Skill>
    {
        SystemDbContext _dbContext;

        public SkillRepository(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Skill item)
        {
            _dbContext.Skills.Add(item);
        }

        public void Delete(int id)
        {
            Skill skill = _dbContext.Skills.Find(id);
            if (skill != null)
                _dbContext.Skills.Remove(skill);
        }

        public IEnumerable<Skill> Find(Func<Skill, bool> predicate)
        {
            return _dbContext.Skills.Where(predicate);
        }

        public Skill Get(int id)
        {
            return _dbContext.Skills.Find(id);
        }

        public IEnumerable<Skill> GetAll()
        {
            return _dbContext.Skills;
        }

        public void Update(Skill item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
