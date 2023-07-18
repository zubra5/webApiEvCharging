using Autofac;
using Data;
using Data.Configuration;
using Data.Interfaces;
using Data.Interfaces.Configuration;

namespace Dependencies.Infrasctructure.ChargingSession
{
    public static class ChargingSessionRepositoryDependencies
    {
        public static ContainerBuilder RegisterChargingSessionRepository(this ContainerBuilder builder)
        {
            builder.RegisterType<ChargingSessionRepository>().As<IChargingSessionRepository>();
            builder.RegisterType<ChargingSessionRepositoryConfig>().As<IChargingSessionRepositoryConfig>().SingleInstance();
            return builder;
        }
    }
}
