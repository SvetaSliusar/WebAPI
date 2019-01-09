using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class ProgrammerProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<SkillRate> SkillRates { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ProgrammerProfile()
        {
            SkillRates = new List<SkillRate>();
        }
    }
}
