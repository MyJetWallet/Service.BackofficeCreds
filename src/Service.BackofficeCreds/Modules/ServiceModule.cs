using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Service.BackofficeCreds.Postgres;
using Service.BackofficeCreds.Services;

namespace Service.BackofficeCreds.Modules
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
                .RegisterType<BoCredManager>()
                .AsSelf()
                .SingleInstance();
        }
    }
}