using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Interfaces
{
    public interface IProgrammerService
    {
        void AddSkillRates(string userName, List<SkillRateBLL> skillRates);
        IEnumerable<ProgrammerBLL> GetAllProgrammers();
        IEnumerable<SkillRateBLL> GetSkillRates(string userName);
    }
}
