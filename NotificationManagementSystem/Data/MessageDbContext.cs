using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NotificationManagementSystem.Models;
using System.IO;

namespace NotificationManagementSystem.Data
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext()
        {
        }

        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DBconnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Message> Messages { get; set; }
    }
}
