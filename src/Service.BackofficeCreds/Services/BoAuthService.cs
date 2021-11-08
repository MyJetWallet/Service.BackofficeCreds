using System.Threading.Tasks;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Grpc.Models;

namespace Service.BackofficeCreds.Services
{
    public class BoAuthService : IBoAuthService
    {
        public Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}