namespace Service.BackofficeCreds.Domain.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Telegram { get; set; }
        public bool IsActive { get; set; }
    }
}