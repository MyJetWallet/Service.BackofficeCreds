using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class RemoveUserRequest
    {
        [DataMember(Order = 1)] public string UserEmail { get; set; }
    }
}