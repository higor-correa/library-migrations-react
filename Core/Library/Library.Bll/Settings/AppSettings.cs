using Library.Bll.Settings.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Library.Bll.Settings
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public string PrivateKey => _configuration.GetSection("Token").GetValue<string>("PrivateKey");
        public int TokenExpiresIn => _configuration.GetSection("Token").GetValue<int>("ExpiresIn");

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
