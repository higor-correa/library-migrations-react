using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Repository.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        private IConfigurationRoot _configuration;

        public DesignTimeDbContextFactory()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()+"/../Library.Api/")
                .AddJsonFile("appsettings.json").Build();
        }

        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString(_configuration.GetValue<string>("Db")));

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
