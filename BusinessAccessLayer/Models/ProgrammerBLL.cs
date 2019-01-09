using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class ProgrammerBLL
    {
        public string UserName { get; set; }
        public ICollection<SkillRateBLL> SkillRates {get; set;}
    }
}
