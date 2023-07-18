using Data.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;

namespace Data.Configuration
{
    public class ChargingSessionRepositoryConfig : IChargingSessionRepositoryConfig
    {
        public const string NameOfSection = "ChargingSessionFileStore";
        public string FileName { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        public ChargingSessionRepositoryConfig()
        {
        }

        public ChargingSessionRepositoryConfig(IConfiguration configuration)
        {
            configuration.GetSection(NameOfSection).Bind(this);
        }
    }
}
