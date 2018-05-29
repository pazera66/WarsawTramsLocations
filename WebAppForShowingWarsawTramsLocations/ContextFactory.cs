using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebAppForShowingWarsawTramsLocalization
{
    public class ContextFactory : IDesignTimeDbContextFactory<DatabaseContext.DatabaseContext>
    {
        public DatabaseContext.DatabaseContext CreateDbContext(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<DatabaseContext.DatabaseContext>();

            builder.UseSqlServer(configuration.GetConnectionString("DBConnectionString"));
            return new DatabaseContext.DatabaseContext(builder.Options);
        }
    }
}
