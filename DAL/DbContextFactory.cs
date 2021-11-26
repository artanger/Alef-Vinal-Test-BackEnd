using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AlefVinalDbContext>
    {
        public AlefVinalDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<AlefVinalDbContext>();

            var connectionString = configuration.GetConnectionString("AlefVinal");

            dbContextBuilder.UseSqlServer(connectionString);

            return new AlefVinalDbContext(dbContextBuilder.Options);
        }
    }
}
