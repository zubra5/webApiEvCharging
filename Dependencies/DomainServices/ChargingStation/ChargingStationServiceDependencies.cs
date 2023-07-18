using Autofac;
using Dependencies.Infrasctructure.Charger;
using Dependencies.Infrasctructure.ChargingStation;
using DomainServices;
using DomainServices.Interfaces;
using DomainServices.Interfaces.Validation;
using DomainServices.Validation;

namespace Dependencies.DomainServices.ChargingStation
{
    public static class ChargingStationServiceDependencies
    {
        public static ContainerBuilder RegisterChargingStationDomain(this ContainerBuilder builder)
        {
            builder.RegisterType<ChargerValidationService>().As<IChargerValidationService>();
            builder.RegisterType<ChargingStationService>().As<IChargingStationService>();
            builder.RegisterChargingStationRepository();          
            return builder;
        }
    }
}
