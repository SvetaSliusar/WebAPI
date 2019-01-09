using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<SkillBLL> GetSkills();
        IEnumerable<SkillBLL> GetSkills(string category);
        IEnumerable<string> GetSkillCategories();
        //void AddSkill(SkillBLL);
    }
}
