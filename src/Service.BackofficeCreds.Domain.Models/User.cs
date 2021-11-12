using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Domain.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Order = 1)] public string Email { get; set; }
        [DataMember(Order = 2)] public string Phone { get; set; }
        [DataMember(Order = 3)] public string Telegram { get; set; }
        [DataMember(Order = 4)] public bool IsActive { get; set; }
    }
}