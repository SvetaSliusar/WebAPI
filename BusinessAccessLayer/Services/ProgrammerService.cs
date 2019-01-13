using AutoMapper;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class ProgrammerService : IProgrammerService
    {
        IUnitOfWork DataBase { get; set; }
        IMapper _mapper;

        public ProgrammerService(IUnitOfWork db)
        {
            DataBase = db;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skill, SkillBLL>()
                .ForMember(dst => dst.Category, opt => opt.MapFrom(src => src.SkillCategory.Name));
                cfg.CreateMap<ProgrammerProfile, ProgrammerBLL>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName));
                cfg.CreateMap<SkillRateBLL, SkillRate>();
            }
            ));
        }

        public void AddSkillRates(string userName, List<SkillRateBLL> skillRates)
        {         
            ApplicationUser user = DataBase.UserManager.Users.First((data) => data.UserName == userName);
            var programmer = DataBase.ProgrammerManager.Get(user.Id);
            foreach (var rate in skillRates)
            {
                var rateDAL = new SkillRate()
                {
                    UserId = programmer.Id,
                    SkillId = rate.Skill.Id,
                    Level = rate.Level
                };
                DataBase.ProgrammerManager.CreateProgrammerSkillRate(rateDAL);
            }           
        }

        public IEnumerable<SkillRateBLL> GetSkillRates(string userName)
        {
            ApplicationUser user = DataBase.UserManager.Users.First((data) => data.UserName == userName);
            var profile = DataBase.ProgrammerManager.Get(user.Id);
            var programmer = _mapper.Map<ProgrammerBLL>(profile);
            return programmer.SkillRates;
        }
        
        public IEnumerable<ProgrammerBLL> GetAllProgrammers()
        {
            var profiles = DataBase.ProgrammerManager.GetAll();
            return _mapper.Map<IEnumerable<ProgrammerBLL>>(profiles);
        }

    }
}
