namespace SMDCheckSheet.Dtos
{
    public class AccountCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; } // nên hash ở service
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AccountReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AccountUpdateDto
    {
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AuthResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class ChangePasswordByAdminDto
    {
        public int AccountId { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }


}
