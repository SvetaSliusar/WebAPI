using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using DataAccessLayer.Interfaces;
using Microsoft.AspNet.Identity;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;

namespace BusinessAccessLayer.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork DataBase { get; set; }
        IMapper _mapper;

        public UserService(IUnitOfWork db)
        {
            DataBase = db;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserBLL>()).CreateMapper();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserBLL user, string authenticationType)
        {
            ApplicationUser appUser = await DataBase.UserManager.FindByNameAsync(user.UserName);
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await DataBase.UserManager.CreateIdentityAsync(appUser, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }        

        public async Task SetInitialData(UserBLL admin, List<string> roles)
        {
            foreach(var roleName in roles)
            {
                ApplicationRole findRole = await DataBase.RoleManager.FindByNameAsync(roleName);
                if (findRole == null)
                {
                    ApplicationRole role = new ApplicationRole { Name = roleName };
                    await DataBase.RoleManager.CreateAsync(role);
                }
            }
            await CreateAsync(admin);
        }

        public async Task<ClaimsIdentity> Authentificate(UserBLL userBLL)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await DataBase.UserManager.FindAsync(userBLL.UserName, userBLL.Password);
            if (user != null)
                claim = await DataBase.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;

        }

        public Task<UserBLL> FindByIdAsync(string userId)
        {
            return _mapper.Map<Task<UserBLL>>(DataBase.UserManager.FindByIdAsync(userId));
        }

        public Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            return DataBase.UserManager.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public Task<IdentityResult> AddPasswordAsync(string userId, string password)
        {
            return DataBase.UserManager.AddPasswordAsync(userId, password);
        }

        public async Task<IdentityResult> CreateAsync(UserBLL user, string password)
        {
            var appUser = new ApplicationUser { Email = user.Email, UserName = user.Email };

            IdentityResult result = await DataBase.UserManager.CreateAsync(appUser, password);

            if (result.Succeeded)
            {
                await DataBase.UserManager.AddToRoleAsync(appUser.Id, user.Role);
                ProgrammerProfile programmer = new ProgrammerProfile
                {
                    Id = appUser.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                DataBase.ProgrammerManager.Create(programmer);
                await DataBase.SaveAsync();
                return result;
            }
            return result;
        }

        public Task<IdentityResult> CreateAsync(UserBLL user)
        {
            return CreateAsync(user, user.Password);
        }

        public Task<UserBLL> FindAsync(string userName, string password)
        {
            return _mapper.Map<Task<UserBLL>>(DataBase.UserManager.FindAsync(userName, password));
        }

        public Task<IdentityResult> AddLoginAsync(string v, UserLoginInfo userLoginInfo)
        {
            return DataBase.UserManager.AddLoginAsync(v, userLoginInfo);
        }

        public Task<IdentityResult> RemoveLoginAsync(string v, UserLoginInfo userLoginInfo)
        {
            return DataBase.UserManager.RemoveLoginAsync(v, userLoginInfo);
        }

        public Task<IdentityResult> RemovePasswordAsync(string v)
        {
            return DataBase.UserManager.RemovePasswordAsync(v);
        }

        public Task<UserBLL> FindAsync(UserLoginInfo userLoginInfo)
        {
            return _mapper.Map<Task<UserBLL>>(DataBase.UserManager.FindAsync(userLoginInfo));
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
