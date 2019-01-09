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
    public class CategoryRepository : IRepository<int, SkillCategory>
    {
        SystemDbContext _dbContext;

        public CategoryRepository(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(SkillCategory item)
        {
            _dbContext.SkillCategories.Add(item);
        }

        public void Delete(int id)
        {
            SkillCategory category = _dbContext.SkillCategories.Find(id);
            if (category != null)
                _dbContext.SkillCategories.Remove(category);
        }

        public IEnumerable<SkillCategory> Find(Func<SkillCategory, bool> predicate)
        {
            return _dbContext.SkillCategories.Where(predicate);
        }

        public SkillCategory Get(int id)
        {
            return _dbContext.SkillCategories.Find(id);
        }

        public IEnumerable<SkillCategory> GetAll()
        {
            return _dbContext.SkillCategories;
        }

        public void Update(SkillCategory item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
