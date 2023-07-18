using Data.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;

namespace Data.Configuration
{
    public class ReservationRepositoryConfig : IReservationRepositoryConfig
    {
        public const string NameOfSection = "ReservationFileStore";
        public string FileName { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        public ReservationRepositoryConfig()
        {
        }

        public ReservationRepositoryConfig(IConfiguration configuration)
        {
            configuration.GetSection(NameOfSection).Bind(this);
        }
    }
}
