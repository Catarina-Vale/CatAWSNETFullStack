using System.Threading.Tasks;
using UserManagementService.Models;
using UserManagementService.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagementService.DTOs;
using System;

namespace UserManagementService.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<User> RegisterAsync(RegisterRequest register);

        public Task<User> LoginAsync(LoginRequest request);
    }
}