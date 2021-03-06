using Autofac;
using Service.BackofficeCreds.Blazor.Engines;
using Service.BackofficeCreds.Blazor.Services;
using Service.BackofficeCreds.Grpc;
using Service.BackofficeCreds.Postgres;

namespace Service.BackofficeCreds.Blazor.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DatabaseContextFactory>()
                .AsSelf()
                .SingleInstance();
            
            builder
                .RegisterType<BoCredManagerEngine>()
                .AsSelf()
                .SingleInstance();
            
            builder
                .RegisterType<BoAuthEngine>()
                .AsSelf()
                .SingleInstance();
        }
    }
}