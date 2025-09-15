using System.Threading.Tasks;
using UserManagementService.Models;
using UserManagementService.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagementService.DTOs;
using System;
using UserManagementService.Services.Interfaces;

namespace UserManagementService.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuroraDbContext _context;

        public AuthService(AuroraDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(RegisterRequest register)
        {
            var hashedPassword = HashPassword(register.Password);
            var user = new UserManagementService.Models.User
            {
                Handle = register.Handle,
                PasswordHash = hashedPassword,
                DisplayName = register.DisplayName,
                Bio = register.Bio
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Handle == request.Username);
            if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
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