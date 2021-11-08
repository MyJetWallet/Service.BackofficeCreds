using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember(Order = 1)] public string Email { get; set; }
    }
}