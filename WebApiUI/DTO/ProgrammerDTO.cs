using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.DTO
{
    public class ProgrammerDTO
    {
        public string UserName { get; set; }
        public IEnumerable<SkillRateDTO> SkillRates { get; set; }
    }
}