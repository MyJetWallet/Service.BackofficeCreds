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

        public BoCredService(ILogger<BoCredService> logger)
        {
            _logger = logger;
        }

        public async Task<BaseResponse> CreateUserAsync(CreateUserRequest request)
        {
            _logger.LogInformation("{methodName} received request: {requestJson}", 
                MethodBase.GetCurrentMethod()?.Name, JsonConvert.SerializeObject(request));
            try
            {
                // doSmth
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
                // doSmth
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
                // doSmth
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
                // doSmth
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
                // doSmth
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
