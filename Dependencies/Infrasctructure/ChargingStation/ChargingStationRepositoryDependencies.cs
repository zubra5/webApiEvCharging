using Autofac;
using Data;
using Data.Configuration;
using Data.Interfaces;
using Data.Interfaces.Configuration;

namespace Dependencies.Infrasctructure.ChargingStation
{
    public static class ChargingStationRepositoryDependencies
    {
        public static ContainerBuilder RegisterChargingStationRepository(this ContainerBuilder builder)
        {
            builder.RegisterType<ChargingStationRepository>().As<IChargingStationRepository>();
            builder.RegisterType<ChargingStationRepositoryConfig>().As<IChargingStationRepositoryConfig>().SingleInstance();
            return builder;
        }
    }
}
