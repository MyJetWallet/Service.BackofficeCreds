using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class SetupRolesRequest
    {
        [DataMember(Order = 1)] public string Email { get; set; }
        [DataMember(Order = 2)] public List<string> Roles { get; set; }
    }
}