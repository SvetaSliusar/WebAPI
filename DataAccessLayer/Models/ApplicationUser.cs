using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
namespace DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {        
        public virtual ProgrammerProfile ClientProfile { get; set; }
    }
}