using System.Runtime.Serialization;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}