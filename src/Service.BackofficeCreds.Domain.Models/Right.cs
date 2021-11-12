using System.Runtime.Serialization;

namespace Service.BackofficeCreds.Domain.Models
{
    [DataContract]
    public class Right
    {
        [DataMember(Order = 1)] public long Id { get; set; }
        [DataMember(Order = 2)] public string Name { get; set; }
        [DataMember(Order = 3)] public string Service { get; set; }
    }
}