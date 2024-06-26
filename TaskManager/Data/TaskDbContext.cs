using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TaskManager.Models;


namespace TaskManager.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        // DbSet for each entity
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure PostgreSQL connection using environment variables
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();

                string connectionString = configuration.GetConnectionString("TaskDbConnection") 
                        ?? throw new InvalidOperationException("TaskDbConnection is not configured.");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure modelBuilder for any additional settings or relationships
            modelBuilder.Entity<Models.User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);

            // Call base OnModelCreating to configure base DbContext behavior
            base.OnModelCreating(modelBuilder);
        }
    }
}
