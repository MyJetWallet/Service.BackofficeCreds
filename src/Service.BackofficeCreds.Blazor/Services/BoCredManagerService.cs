using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.BackofficeCreds.Blazor.Engines;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Blazor.Services
{
    public class BoCredManagerService: IBoCredManagerService
    {
        private readonly ILogger<BoCredManagerService> _logger;
        private readonly BoCredManagerEngine _boCredManagerEngine;

        public BoCredManagerService(ILogger<BoCredManagerService> logger, 
            BoCredManagerEngine boCredManagerEngine)
        {
            _logger = logger;
            _boCredManagerEngine = boCredManagerEngine;
        }

        public async Task<BaseResponse> CreateUserAsync(CreateUserRequest request)
        {
            _logger.LogInformation("CreateUserAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManagerEngine.CreateUserAsync(request.Email, request.Phone, request.Telegram, request.IsActive);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"CreateUserAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new BaseResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<BaseResponse> CreateRoleAsync(CreateRoleRequest request)
        {
            _logger.LogInformation("CreateRoleAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManagerEngine.CreateRoleAsync(request.Name);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"CreateRoleAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new BaseResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<BaseResponse> SetupRolesAsync(SetupRolesRequest request)
        {
            _logger.LogInformation("SetupRolesAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManagerEngine.SetupRolesAsync(request.UserEmail, request.RolesName);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"SetupRolesAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new BaseResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<BaseResponse> RemoveUserAsync(RemoveUserRequest request)
        {
            _logger.LogInformation("RemoveUserAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManagerEngine.RemoveUserAsync(request.UserEmail);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"RemoveUserAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new BaseResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<BaseResponse> RemoveRoleAsync(RemoveRoleRequest request)
        {
            _logger.LogInformation("RemoveRoleAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManagerEngine.RemoveRoleAsync(request.RoleName);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"RemoveRoleAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new BaseResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }
    }
}
