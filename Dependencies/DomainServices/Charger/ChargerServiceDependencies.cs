using Autofac;
using Dependencies.Infrasctructure.Charger;
using DomainServices;
using DomainServices.Interfaces;

namespace Dependencies.DomainServices.Charger
{
    public static class ChargerServiceDependencies
    {
        public static ContainerBuilder RegisterChargerDomain(this ContainerBuilder builder)
        {
            builder.RegisterType<ChargerService>().As<IChargerService>();
            builder.RegisterChargerRepository();
            return builder;
        }
    }
}
