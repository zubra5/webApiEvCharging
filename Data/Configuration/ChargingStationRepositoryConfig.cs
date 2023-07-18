using Data.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;

namespace Data.Configuration
{
    public class ChargingStationRepositoryConfig : IChargingStationRepositoryConfig
    {
        public const string NameOfSection = "ChargingStationFileStore";
        public string FileName { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        public ChargingStationRepositoryConfig()
        {
        }

        public ChargingStationRepositoryConfig(IConfiguration configuration)
        {
            configuration.GetSection(NameOfSection).Bind(this);
        }
    }
}
