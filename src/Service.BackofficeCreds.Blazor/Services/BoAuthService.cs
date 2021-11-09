using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Blazor.Services
{
    public class BoAuthService : IBoAuthService
    {
        private readonly ILogger<BoAuthService> _logger;

        public BoAuthService(ILogger<BoAuthService> logger)
        {
            _logger = logger;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            _logger.LogInformation("LoginAsync received request: {requestJson}", JsonConvert.SerializeObject(request));
            try
            {
                return new LoginResponse()
                {
                    Success = true,
                    Token = "test"
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