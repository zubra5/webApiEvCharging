using Autofac;
using Dependencies.Infrasctructure.Charger;
using Dependencies.Infrasctructure.Reservation;
using DomainServices;
using DomainServices.Configuration;
using DomainServices.Interfaces;
using DomainServices.Interfaces.Configuration;
using DomainServices.Interfaces.Validation;
using DomainServices.Validation;

namespace Dependencies.DomainServices.Reservation
{
    public static class ReservationServiceDependencies
    {
        public static ContainerBuilder RegisterReservationDomain(this ContainerBuilder builder)
        {
            builder.RegisterType<ReservationService>().As<IReservationService>();
            builder.RegisterType<ReservationConfig>().As<IReservationConfig>().SingleInstance(); ;
            builder.RegisterType<ChargerValidationService>().As<IChargerValidationService>();
            builder.RegisterReservationRepostitory();           
            return builder;
        }
    }
}
