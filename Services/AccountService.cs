using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class AccountService
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenService _jwt;

        public AccountService(AppDbContext context, JwtTokenService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<IEnumerable<AccountReadDto>> GetAllAsync()
        {
            return await _context.Accounts
                .Select(a => new AccountReadDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Role = a.Role,
                    IsActive = a.IsActive
                }).ToListAsync();
        }

        public async Task<AccountReadDto?> GetByIdAsync(int id)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return null;

            return new AccountReadDto
            {
                Id = acc.Id,
                Username = acc.Username,
                Role = acc.Role,
                IsActive = acc.IsActive
            };
        }

        public async Task<AccountReadDto> CreateAsync(AccountCreateDto dto)
        {
            var acc = new Account
            {
                Username = dto.Username,
                Password = HashPassword(dto.Password),
                Role = dto.Role,
                IsActive = dto.IsActive
            };

            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();

            return new AccountReadDto
            {
                Id = acc.Id,
                Username = acc.Username,
                Role = acc.Role,
                IsActive = acc.IsActive
            };
        }

        public async Task<bool> UpdateAsync(int id, AccountUpdateDto dto)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return false;

            acc.Password = HashPassword(dto.Password);
            acc.Role = dto.Role;
            acc.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return false;

            _context.Accounts.Remove(acc);
            await _context.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            // TODO: Replace with real hashing (e.g., BCrypt)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPassword(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
  
        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == dto.Username);
            if(account == null || !account.IsActive) return null;

            if(!VerifyPassword(dto.Password, account.Password)) return null;

            var (token, exp) = _jwt.GenerateToken(account.Id, account.Username, account.Role);

            return new AuthResponseDto
            {
                Id = account.Id,
                Username = account.Username,
                Role = account.Role,
                Token = token,
                ExpiresAt = exp
            };
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto)
        {
            // kiểm tra trùng username
            if (await _context.Accounts.AnyAsync(a => a.Username == dto.Username))
                return null;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var account = new Account
            {
                Username = dto.Username,
                Password = hashedPassword,
                Role = dto.Role,
                IsActive = true
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            var (token, exp) = _jwt.GenerateToken(account.Id, account.Username, account.Role);

            return new AuthResponseDto
            {
                Id = account.Id,
                Username = account.Username,
                Role = account.Role,
                Token = token,
                ExpiresAt = exp
            };
        }

    }
}
