using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class RemoveRoleRequest
    {
        [DataMember(Order = 1)] public long RoleId { get; set; }
    }
}