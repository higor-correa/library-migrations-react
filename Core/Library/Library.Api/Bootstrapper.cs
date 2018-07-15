using Library.Api.Extensions;
using Library.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Api
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
            _services.AddDbContext<LibraryContext>(opt => opt.UseNpgsql(
                _configuration.GetConnectionString(
                    _configuration.GetValue<string>("Db"))));

            _services.AddLibrary();
        }
    }
}
