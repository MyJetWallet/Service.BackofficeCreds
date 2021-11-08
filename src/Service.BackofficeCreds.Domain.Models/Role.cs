namespace Service.BackofficeCreds.Domain.Models
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsSupervisor { get; set; }
    }
}