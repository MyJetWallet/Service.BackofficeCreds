using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Grpc.Models;
using Service.BackofficeCreds.Settings;

namespace Service.BackofficeCreds.Services
{
    public class BoCredService: IBoCredService
    {
        private readonly ILogger<BoCredService> _logger;

        public BoCredService(ILogger<BoCredService> logger)
        {
            _logger = logger;
        }

        public Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<SetupRolesResponse> SetupRolesAsync(SetupRolesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<InitRightsResponse> InitRightsAsync(InitRightsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RemoveUserResponse> RemoveUserAsync(RemoveUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RemoveRoleResponse> RemoveRoleAsync(RemoveRoleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
