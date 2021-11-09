using System;
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
                var token = await _boAuthEngine.Login(request.Email);

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
    }
}