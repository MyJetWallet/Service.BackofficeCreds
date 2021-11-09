using System.Collections.Generic;

namespace Service.BackofficeCreds.Domain.Models
{
    public class RoleWithRights
    {
        public Role Role { get; set; }
        public List<Right> Rights { get; set; }
    }
}