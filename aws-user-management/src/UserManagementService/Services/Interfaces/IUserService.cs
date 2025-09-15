using System.Threading.Tasks;
using UserManagementService.Data;
using UserManagementService.DTOs;
using UserManagementService.Models;

namespace UserManagementService.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByIdAsync(string userId);

        public Task<bool> UpdateUserProfileAsync(UpdateProfileRequest request);
    }
}