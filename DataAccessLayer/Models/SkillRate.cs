using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public enum Level
    {
        Junior, Middle, Senior
    }

    public class SkillRate
    {
        [Key, Column(Order = 1)]
        [ForeignKey("ProgrammerProfile")]
        public string UserId { get; set; }
        [Key, Column(Order = 2)]
        public int SkillId { get; set; }
        public int Level { get; set; }

        public virtual ProgrammerProfile ProgrammerProfile { get; set; }
        public virtual Skill Skill {get; set;}
    }
}
