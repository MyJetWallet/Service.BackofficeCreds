using System.ServiceModel;
using System.Threading.Tasks;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Grpc
{
    [ServiceContract]
    public interface IBoCredManagerService
    {
        [OperationContract]
        Task<BaseResponse> CreateUserAsync(CreateUserRequest request);
        [OperationContract]
        Task<BaseResponse> CreateRoleAsync(CreateRoleRequest request);
        [OperationContract]
        Task<BaseResponse> SetupRolesAsync(SetupRolesRequest request);
        [OperationContract]
        Task<BaseResponse> InitRightsAsync(InitRightsRequest request);
        [OperationContract]
        Task<BaseResponse> RemoveUserAsync(RemoveUserRequest request);
        [OperationContract]
        Task<BaseResponse> RemoveRoleAsync(RemoveRoleRequest request);
    }
}