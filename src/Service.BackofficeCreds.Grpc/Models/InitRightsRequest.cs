using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class InitRightsRequest
    {
        [DataMember(Order = 1)] public List<string> Rights { get; set; }
    }
}