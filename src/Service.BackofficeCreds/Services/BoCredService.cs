using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Services
{
    public class BoCredService: IBoCredService
    {
        private readonly ILogger<BoCredService> _logger;
        private readonly BoCredManager _boCredManager;

        public BoCredService(ILogger<BoCredService> logger, 
            BoCredManager boCredManager)
        {
            _logger = logger;
            _boCredManager = boCredManager;
        }

        public async Task<BaseResponse> CreateUserAsync(CreateUserRequest request)
        {
            _logger.LogInformation("{methodName} received request: {requestJson}", 
                MethodBase.GetCurrentMethod()?.Name, JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManager.CreateUserAsync(request.Email);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"{MethodBase.GetCurrentMethod()?.Name} catch exception : {ex.Message}";
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
            _logger.LogInformation("{methodName} received request: {requestJson}", 
                MethodBase.GetCurrentMethod()?.Name, JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManager.SetupRolesAsync(request.UserId, request.RolesId);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"{MethodBase.GetCurrentMethod()?.Name} catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new BaseResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<BaseResponse> InitRightsAsync(InitRightsRequest request)
        {
            _logger.LogInformation("{methodName} received request: {requestJson}", 
                MethodBase.GetCurrentMethod()?.Name, JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManager.InitRightsAsync(request.Rights);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"{MethodBase.GetCurrentMethod()?.Name} catch exception : {ex.Message}";
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
            _logger.LogInformation("{methodName} received request: {requestJson}", 
                MethodBase.GetCurrentMethod()?.Name, JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManager.RemoveUserAsync(request.UserId);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"{MethodBase.GetCurrentMethod()?.Name} catch exception : {ex.Message}";
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
            _logger.LogInformation("{methodName} received request: {requestJson}", 
                MethodBase.GetCurrentMethod()?.Name, JsonConvert.SerializeObject(request));
            try
            {
                await _boCredManager.RemoveRoleAsync(request.RoleId);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"{MethodBase.GetCurrentMethod()?.Name} catch exception : {ex.Message}";
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
