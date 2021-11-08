using Autofac;
using Service.BackofficeCreds.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.BackofficeCreds.Client
{
    public static class AutofacHelper
    {
        public static void RegisterBackofficeCredsManagerClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new BackofficeCredsClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetBoCredService()).As<IBoCredManagerService>().SingleInstance();
        }
        
        public static void RegisterBackofficeCredsAuthClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new BackofficeCredsClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetBoAuthService()).As<IBoAuthService>().SingleInstance();
        }
    }
}
