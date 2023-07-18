using Autofac;
using Dependencies.Infrasctructure.ChargingSession;
using DomainServices;
using DomainServices.Interfaces;

namespace Dependencies.DomainServices.ChargingSession
{
    public static class ChargingSessionServiceDependencies
    {
        public static ContainerBuilder RegisterChargingSessionDomain(this ContainerBuilder builder)
        {
            builder.RegisterType<ChargingSessionService>().As<IChargingSessionService>();
            builder.RegisterChargingSessionRepository();
            return builder;
        }
    }
}
