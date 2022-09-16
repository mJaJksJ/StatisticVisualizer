namespace StatisticVisualizer.Models
{
    /// <summary>
    /// Модель представления Upload
    /// </summary>
    public class UploadModel
    {
        /// <summary>
        /// Всего обработанных строк
        /// </summary>
        public int TotalProcessedRows { get; set; }

        /// <summary>
        /// Успешно обработанных строк
        /// </summary>
        public int SuccesedProcessedRows { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Ошибка
        /// </summary>
        public string Error { get; set; }
    }
}
