using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class RemoveUserRequest
    {
        [DataMember(Order = 1)] public long UserId { get; set; }
    }
}