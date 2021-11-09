using System.Collections.Generic;

namespace Service.BackofficeCreds.Domain.Models
{
    public class UserWithRole
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
    }
}