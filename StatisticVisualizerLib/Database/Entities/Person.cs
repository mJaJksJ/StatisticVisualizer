using Microsoft.EntityFrameworkCore;

namespace StatisticVisualizerLib.Database.Entities
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Id города
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Пол: <br/> <i>true - мужчина</i> <br/> <i>false - женщина</i>
        /// </summary>
        public bool IsMale { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Person>();

            entity.ToTable("people");
            entity.HasKey(t => t.Id);

            entity.HasOne(e => e.City);
        }
    }
}
