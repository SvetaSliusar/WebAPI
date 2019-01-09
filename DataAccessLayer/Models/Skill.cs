using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("SkillCategory")]
        public int CategoryId { get; set; }

        public virtual ICollection<SkillRate> SkillRates { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }

        public Skill()
        {
            SkillRates = new List<SkillRate>();
        }
    }
}
