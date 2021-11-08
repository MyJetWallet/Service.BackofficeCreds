using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.BackofficeCreds.Grpc;

namespace Service.BackofficeCreds.Client
{
    [UsedImplicitly]
    public class BackofficeCredsClientFactory: MyGrpcClientFactory
    {
        public BackofficeCredsClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
