using Data.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;

namespace Data.Configuration
{
    public class ChargerRepositoryConfig : IChargerRepositoryConfig
    {
        public const string NameOfSection = "ChargerFileStore";
        public string FileName { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        public ChargerRepositoryConfig()
        {
        }

        public ChargerRepositoryConfig(IConfiguration configuration)
        {
            configuration.GetSection(NameOfSection).Bind(this);
        }
    }
}
