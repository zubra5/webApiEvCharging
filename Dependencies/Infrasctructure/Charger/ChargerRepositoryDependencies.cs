using Autofac;
using Data;
using Data.Configuration;
using Data.Interfaces;
using Data.Interfaces.Configuration;

namespace Dependencies.Infrasctructure.Charger
{
    public static class ChargerRepositoryDependencies
    {
        public static ContainerBuilder RegisterChargerRepository(this ContainerBuilder builder)
        {
            builder.RegisterType<ChargerRepository>().As<IChargerRepository>();
            builder.RegisterType<ChargerRepositoryConfig>().As<IChargerRepositoryConfig>().SingleInstance();
            return builder;
        }
    }
}
