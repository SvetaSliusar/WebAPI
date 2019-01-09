using DataAccessLayer.Models;
using Microsoft.AspNet.Identity;

namespace DataAccessLayer.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> userStore) 
            : base(userStore)
        {

        }
    }
}
