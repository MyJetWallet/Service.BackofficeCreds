using System.Runtime.Serialization;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class CreateUserResponse
    {
        [DataMember(Order = 1)] public bool Success { get; set; }
        [DataMember(Order = 2)] public string ErrorMessage { get; set; }
    }
}