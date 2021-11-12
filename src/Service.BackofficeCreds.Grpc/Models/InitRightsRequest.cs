using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class InitRightsRequest
    {
        [DataMember(Order = 1)] public string Service { get; set; }
        [DataMember(Order = 2)] public List<string> Rights { get; set; }
    }
}