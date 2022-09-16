namespace StatisticVisualizer.Models
{
    /// <summary>
    /// Модель представления ошибки
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id запроса
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Отображаемое id запроса
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
