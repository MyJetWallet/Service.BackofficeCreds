using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class LoginWithoutJwtResponse
    {
        [DataMember(Order = 1)] public bool Success { get; set; }
        [DataMember(Order = 2)] public string ErrorMessage { get; set; }
        [DataMember(Order = 3)] public User User { get; set; }
        [DataMember(Order = 4)] public List<Right> Rights { get; set; }
        [DataMember(Order = 5)] public bool IsSupervisor { get; set; }
    }
}