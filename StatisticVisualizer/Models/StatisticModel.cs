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

        public PageInfo PageInfo { get; set; }
    }
}
