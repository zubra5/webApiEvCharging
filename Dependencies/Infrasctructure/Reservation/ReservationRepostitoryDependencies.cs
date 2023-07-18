using Autofac;
using Data;
using Data.Configuration;
using Data.Interfaces;
using Data.Interfaces.Configuration;

namespace Dependencies.Infrasctructure.Reservation
{
    public static class ReservationRepostitoryDependencies
    {
        public static ContainerBuilder RegisterReservationRepostitory(this ContainerBuilder builder)
        {
            builder.RegisterType<ReservationRepostitory>().As<IReservationRepostitory>();
            builder.RegisterType<ReservationRepositoryConfig>().As<IReservationRepositoryConfig>().SingleInstance();
            return builder;
        }
    }
}
