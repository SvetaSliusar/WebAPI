using AutoMapper;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiUI.DTO;

namespace WebApiUI.Controllers
{
    [Authorize]
    [RoutePrefix("api/programmers")]
    public class ProgrammerController : ApiController
    {
        IProgrammerService _programmerService;
        IMapper _mapper;
        
        public ProgrammerController(IProgrammerService programmerService)
        {
            _programmerService = programmerService;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SkillBLL, SkillDTO>();
                cfg.CreateMap<SkillRateBLL, SkillRateDTO>();
                cfg.CreateMap<ProgrammerBLL, ProgrammerDTO>();
            }).CreateMapper();
        }

        [Route("skills")]
        public void Post(ProgrammerDTO programmer)
        {            
            _programmerService.AddSkillRates(programmer.UserName,_mapper.Map<List<SkillRateBLL>>(programmer.SkillRates));
        }

        [Route("")]
        public IEnumerable<SkillRateDTO> Get(string userName)
        {
            return _mapper.Map<IEnumerable<SkillRateDTO>>(_programmerService.GetSkillRates(userName));
        }

        public IEnumerable<ProgrammerDTO> GetALL()
        {
            return _mapper.Map<IEnumerable<ProgrammerDTO>>(_programmerService.GetAllProgrammers());
        }
    }
}
