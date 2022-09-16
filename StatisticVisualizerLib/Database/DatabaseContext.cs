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

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-89OES6MB;Database=StatisticVisualizer;Trusted_Connection=True;");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            City.Setup(modelBuilder);
            Person.Setup(modelBuilder);
        }
    }
}
