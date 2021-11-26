using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class AlefVinalDbContext: DbContext
    {
        public AlefVinalDbContext(DbContextOptions<AlefVinalDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AlefVinal"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API definitions
            modelBuilder.Entity<Code>().ToTable("Codes").HasKey(c => c.Id);
        }

        public DbSet<Code> Code { get; set; }
    }
}
