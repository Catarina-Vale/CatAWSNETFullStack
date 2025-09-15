using System.Threading.Tasks;
using UserManagementService.Data;
using UserManagementService.DTOs;
using UserManagementService.Models;
using UserManagementService.Services.Interfaces;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly AuroraDbContext _context;

        public UserService(AuroraDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserProfileAsync(UpdateProfileRequest request)
        {
            var user = await GetUserByIdAsync(request.UserId);
            if (user == null) return false;

            user.Bio = request.Bio;
            user.DisplayName = request.DisplayName;
            user.ProfilePictureUrl = request.ProfilePictureUrl;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}