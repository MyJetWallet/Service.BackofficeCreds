using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class CreateUserRequest
    {
        [DataMember(Order = 1)] public string Email { get; set; }
        [DataMember(Order = 2)] public string Phone { get; set; }
        [DataMember(Order = 3)] public string Telegram { get; set; }
        [DataMember(Order = 4)] public bool IsActive { get; set; }
    }
}