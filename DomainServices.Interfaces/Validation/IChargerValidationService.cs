namespace DomainServices.Interfaces.Validation
{
    public interface IChargerValidationService
    {
        Task CheckChargerExisting(int chargerId);

        Task IsChargerAvailable(int chargerId);

        Task<bool> IsChargerReserved(int chargerId, Guid userId);
    }
}
