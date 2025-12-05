using System;

namespace SMDCheckSheet.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // { PQC, ENG, Supervisor, Manager, Manager_Korea}
        public bool IsActive { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}