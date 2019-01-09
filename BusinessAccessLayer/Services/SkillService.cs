using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class SkillService : ISkillService
    {
        IUnitOfWork DataBase { get; set; }
        IMapper _mapper;

        public SkillService(IUnitOfWork db)
        {
            DataBase = db;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Skill, SkillBLL>()).CreateMapper();
        }

        public IEnumerable<SkillBLL> GetSkills()
        {
            return _mapper.Map<IEnumerable<SkillBLL>>(DataBase.Skills.GetAll());
        }

        public IEnumerable<SkillBLL> GetSkills(string category)
        {
            var skills = DataBase.SkillCategories.GetAll().First(c => c.Name == category).Skills;
            return skills.Select(skill=>new SkillBLL { Name=skill.Name, Category=skill.SkillCategory.Name});
        }

        public IEnumerable<string> GetSkillCategories()
        {
            return DataBase.SkillCategories.GetAll().Select(category => category.Name);
        }
    }
}
