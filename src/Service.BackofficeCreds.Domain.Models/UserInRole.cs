namespace Service.BackofficeCreds.Domain.Models
{
    public class UserInRole
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}