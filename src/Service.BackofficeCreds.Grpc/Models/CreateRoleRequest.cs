using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class CreateRoleRequest
    {
        [DataMember(Order = 1)] public string Name { get; set; }
    }
}