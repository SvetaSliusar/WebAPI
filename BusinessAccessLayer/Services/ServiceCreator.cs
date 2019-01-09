using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Services;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connectionString)
        {
            IUserService userService = new UserService(new UnitOfWork(connectionString));
            return userService;
        }

        public ISkillService CreateSkillService(string connectionString)
        {
            ISkillService skillService = new SkillService(new UnitOfWork(connectionString));
            return skillService;
        }
    }
}
