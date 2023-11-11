using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductivityTools.Feedback.Database.Schema;
using System;

namespace ProductivityTools.Feedback.Database
{
    public class TeamManagmentContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TeamManagmentContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Schema.Feedback> Feedback { get; set; }
        public DbSet<Internal> Internal { get; set; }
        public DbSet<Person> Person { get; set; }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                   builder.AddConsole()
                          .AddFilter(DbLoggerCategory.Database.Command.Name,
                                     LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
                optionsBuilder.UseLoggerFactory(GetLoggerFactory());
                optionsBuilder.EnableSensitiveDataLogging();
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tm");
            modelBuilder.Entity<Schema.Feedback>().HasKey(x => x.FeedbackId);
            modelBuilder.Entity<Schema.Feedback>().HasOne(x => x.Person);

            modelBuilder.Entity<Internal>().HasKey(x => x.InternalId);
            modelBuilder.Entity<Internal>().HasOne(x => x.Person);

            modelBuilder.Entity<Person>().HasKey(x => x.PersonId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
