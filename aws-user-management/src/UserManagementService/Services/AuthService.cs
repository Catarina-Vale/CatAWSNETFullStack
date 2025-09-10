using System.Threading.Tasks;
using UserManagementService.Models;
using UserManagementService.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace UserManagementService.Services
{
    public class AuthService
    {
        private readonly AuroraDbContext _context;

        public AuthService(AuroraDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(string handle, string password, string displayName, string bio)
        {
            var hashedPassword = HashPassword(password);
            var user = new User
            {
                Handle = handle,
                PasswordHash = hashedPassword,
                DisplayName = displayName,
                Bio = bio
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginAsync(string handle, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Handle == handle);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}