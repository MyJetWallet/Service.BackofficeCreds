using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class SetupRolesRequest
    {
        [DataMember(Order = 1)] public long UserId { get; set; }
        [DataMember(Order = 2)] public List<long> RolesId { get; set; }
    }
}