namespace SMDCheckSheet.Dtos
{
    public class AccountCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; } // nên hash ở service
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }

    public class AccountReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }

    public class AccountUpdateDto
    {
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
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
    }

    public class AuthResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

}
