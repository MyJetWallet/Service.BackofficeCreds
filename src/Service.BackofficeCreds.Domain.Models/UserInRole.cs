namespace Service.BackofficeCreds.Domain.Models
{
    public class UserInRole
    {
        public long Id { get; set; }
        public string UserEmail { get; set; }
        public string RoleName { get; set; }
    }
}