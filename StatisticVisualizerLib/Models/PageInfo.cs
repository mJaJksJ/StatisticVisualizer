namespace StatisticVisualizer.Models
{
    /// <summary>
    /// Пагинация
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// Текущая страница
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public static int PageSize => 10;

        /// <summary>
        /// Количество элементов всего
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int TotalPages { get; set; }
    }
}
