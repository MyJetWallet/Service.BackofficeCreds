using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.BackofficeCreds.Blazor.Engines;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Blazor.Services
{
    public class BoAuthService : IBoAuthService
    {
        private readonly ILogger<BoAuthService> _logger;
        private readonly BoAuthEngine _boAuthEngine;

        public BoAuthService(ILogger<BoAuthService> logger, 
            BoAuthEngine boAuthEngine)
        {
            _logger = logger;
            _boAuthEngine = boAuthEngine;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            _logger.LogInformation("LoginAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                var token = await _boAuthEngine.Login(request.Service, request.Email);

                if (string.IsNullOrWhiteSpace(token))
                    return new LoginResponse()
                    {
                        Success = false,
                        ErrorMessage = "Cannot find user"
                    };
                return new LoginResponse()
                {
                    Success = true,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"LoginAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new LoginResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<LoginWithoutJwtResponse> LoginWithoutJwtAsync(LoginRequest request)
        {
            _logger.LogInformation("LoginAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                var (user, rights, isSupervisor) = await _boAuthEngine.LoginWithoutJwt(request.Service, request.Email);

                if (user == null)
                    return new LoginWithoutJwtResponse()
                    {
                        Success = false,
                        ErrorMessage = "Cannot find user"
                    };
                return new LoginWithoutJwtResponse()
                {
                    Success = true, 
                    User = user,
                    Rights = rights,
                    IsSupervisor = isSupervisor
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"LoginAsync catch exception : {ex.Message}";
                _logger.LogError(ex, errorMessage);
                return new LoginWithoutJwtResponse()
                {
                    Success = false,
                    ErrorMessage = errorMessage
                };
            }
        }

        public async Task<BaseResponse> InitRightsAsync(InitRightsRequest request)
        {
            _logger.LogInformation("InitRightsAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                await _boAuthEngine.InitRightsAsync(request.Service, request.Rights);
                return new BaseResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                var errorMessage = $"InitRightsAsync catch exception : {ex.Message}";
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