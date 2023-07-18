using Domain;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public static class ChargerStationMapper
    {
        public static ChargingStationViewModel MapToViewModel(        
            this ChargingStation domain, 
            IEnumerable<Charger> chargers) {
            var model = new ChargingStationViewModel();
            model.Location = domain.Location;
            model.Status = domain.Status;
            model.Name = domain.Name;
            model.Id = domain.Id;
            model.Chargers = chargers.Where(x => domain.Chargers.Contains(x.Id)).ToList();

            return model;
        }
    }
}
