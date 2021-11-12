using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class SetupRolesRequest
    {
        [DataMember(Order = 1)] public string UserEmail { get; set; }
        [DataMember(Order = 2)] public List<string> RolesName { get; set; }
    }
}