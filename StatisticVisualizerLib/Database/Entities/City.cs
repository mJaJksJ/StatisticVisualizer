using Microsoft.EntityFrameworkCore;

namespace StatisticVisualizerLib.Database.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<City>();

            entity.ToTable("cities");
            entity.HasKey(t => t.Id);

            entity.HasIndex(t => t.Name);
        }
    }
}
