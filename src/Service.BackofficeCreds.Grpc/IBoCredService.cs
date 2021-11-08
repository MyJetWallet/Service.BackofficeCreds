using System.ServiceModel;
using System.Threading.Tasks;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Grpc
{
    [ServiceContract]
    public interface IBoCredService
    {
        [OperationContract]
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
        
        [OperationContract]
        Task<SetupRolesResponse> SetupRolesAsync(SetupRolesRequest request);
        
        [OperationContract]
        Task<InitRightsResponse> InitRightsAsync(InitRightsRequest request);
        
        [OperationContract]
        Task<RemoveUserResponse> RemoveUserAsync(RemoveUserRequest request);
        [OperationContract]
        Task<RemoveRoleResponse> RemoveRoleAsync(RemoveRoleRequest request);
    }
}