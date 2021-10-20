using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjetoInfraMvc.Contexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("ProjetoMvc").Value;

            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);
        }
    }
}
