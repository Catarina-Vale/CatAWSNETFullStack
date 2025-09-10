using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class UserService
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

        public async Task<bool> UpdateUserProfileAsync(string userId, string bio, string displayName, string profilePictureUrl)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) return false;

            user.Bio = bio;
            user.DisplayName = displayName;
            user.ProfilePictureUrl = profilePictureUrl;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}