using System.ServiceModel;
using System.Threading.Tasks;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Grpc
{
    [ServiceContract]
    public interface IBoAuthService
    {
        [OperationContract]
        Task<LoginResponse> LoginAsync(LoginRequest request);
        
        [OperationContract]
        Task<BaseResponse> InitRightsAsync(InitRightsRequest request);
    }
}