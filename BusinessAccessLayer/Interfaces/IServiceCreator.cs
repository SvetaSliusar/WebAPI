﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connectionString);
        ISkillService CreateSkillService(string connectionString);
    }
}
