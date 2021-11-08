using System.ServiceModel;
using System.Threading.Tasks;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}