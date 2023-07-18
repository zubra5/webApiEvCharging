using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dependencies.DomainServices.Charger;
using Dependencies.DomainServices.ChargingSession;
using Dependencies.DomainServices.ChargingStation;
using Dependencies.DomainServices.Reservation;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            RegisterDependencies(builder);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API EV Charging ", Version = "v1" });

            });

            var app = builder.Build();

            app.UseExceptionHandler("/error");


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterDependencies(WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>((hostBuilderContext, containerBuilder) =>
                {
                    containerBuilder.Register(context => config).As<IConfiguration>();                   

                    containerBuilder.RegisterChargingStationDomain()
                                    .RegisterReservationDomain()
                                    .RegisterChargerDomain()
                                    .RegisterChargingSessionDomain();
                }
            );
        }
    }
}