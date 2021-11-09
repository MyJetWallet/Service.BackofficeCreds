using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.BackofficeCreds.Blazor.Settings
{
    public class SettingsModel
    {
        [YamlProperty("BackofficeCreds.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("BackofficeCreds.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("BackofficeCreds.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("BackofficeCreds.PostgresConnectionString")]
        public string PostgresConnectionString { get; set; }

        [YamlProperty("BackofficeCreds.JwtSecurityKey")]
        public string JwtSecurityKey { get; set; }
        
        [YamlProperty("BackofficeCreds.JwtExpiryInDays")]
        public int JwtExpiryInDays { get; set; }

        [YamlProperty("BackofficeCreds.JwtIssuer")]
        public string JwtIssuer { get; set; }
        
        [YamlProperty("BackofficeCreds.JwtAudience")]
        public string JwtAudience { get; set; }
    }
}
