namespace StatisticVisualizer.Models
{
    /// <summary>
    /// Модель для страницы статистики
    /// </summary>
    public class StatisticModel
    {
        /// <summary>
        /// Люди
        /// </summary>
        public IEnumerable<PersonModel> People { get; set; }

        /// <summary>
        /// Пагинация
        /// </summary>
        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// Количество мужчин
        /// </summary>
        public int MenCount { get; set; }

        /// <summary>
        /// Количество женщин
        /// </summary>
        public int WomenCount { get; set; }

        /// <summary>
        /// Фильтрация по полу (null - Ж+М, true - М, false - Ж)
        /// </summary>
        public bool? IsOnlyMale { get; set; }

        /// <summary>
        /// Ошибка
        /// </summary>
        public string Error { get; set; }
    }
}
