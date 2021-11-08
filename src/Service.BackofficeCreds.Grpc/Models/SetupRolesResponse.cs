using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class SetupRolesResponse
    {
        [DataMember(Order = 1)] public bool Success { get; set; }
        [DataMember(Order = 2)] public string ErrorMessage { get; set; }
    }
}