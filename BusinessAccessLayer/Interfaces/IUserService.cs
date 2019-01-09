using BusinessAccessLayer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IdentityResult> CreateAsync(UserBLL user, string password);
        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserBLL user, string authenticationType);
        Task<IdentityResult> CreateAsync(UserBLL user);
        Task<ClaimsIdentity> Authentificate(UserBLL user);
        Task SetInitialData(UserBLL admin, List<string> roles);
        Task<UserBLL> FindByIdAsync(string userId);
        Task<UserBLL> FindAsync(string userName, string password);
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<IdentityResult> AddPasswordAsync(string userId, string password);
        Task<IdentityResult> AddLoginAsync(string v, UserLoginInfo userLoginInfo);
        Task<IdentityResult> RemoveLoginAsync(string v, UserLoginInfo userLoginInfo);
        Task<IdentityResult> RemovePasswordAsync(string v);
        Task<UserBLL> FindAsync(UserLoginInfo userLoginInfo);
    }
}
