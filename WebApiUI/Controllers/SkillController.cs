using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebApiUI.DTO;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class SkillController : ApiController
    {
        ISkillService _skillService;
        IMapper _mapper;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<SkillBLL, SkillDTO>()).CreateMapper();
        }

        [Route("api/skills")]
        public IEnumerable<SkillDTO> Get()
        {
            return _mapper.Map<IEnumerable<SkillDTO>>(_skillService.GetSkills());
        }

        [Route("api/skills")]
        public IEnumerable<SkillDTO> Get(string category)
        {
            return _mapper.Map<IEnumerable<SkillDTO>>(_skillService.GetSkills(category));
        }

        [Route("api/skills/categories")]
        public IEnumerable<string> GetSkillCategories()
        {
            return _skillService.GetSkillCategories();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
