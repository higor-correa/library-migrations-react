using Library.Bll.Settings.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Bll.Settings
{
    public class Bootstrapper
    {
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public Bootstrapper(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Register()
        {
            _services.ConfigureDb(_configuration);
            _services.AddLibrary();
            _services.AddAutoMapper();
            //_services.AddJwtAuthentication(_configuration.GetSection("Token").GetValue<string>("PrivateKey"));
        }
    }
}
