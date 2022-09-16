using Microsoft.EntityFrameworkCore;
using StatisticVisualizerLib.Database.Entities;

namespace StatisticVisualizerLib.Database
{
    /// <inheritdoc cref="DatabaseContext"/>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Города
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Люди
        /// </summary>
        public DbSet<Person> People { get; set; }

        private readonly string _connectionString;

        /// <summary>
        /// .ctor
        /// </summary>
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            City.Setup(modelBuilder);
            Person.Setup(modelBuilder);
        }
    }
}
