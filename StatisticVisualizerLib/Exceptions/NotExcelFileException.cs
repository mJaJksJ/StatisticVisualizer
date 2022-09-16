namespace StatisticVisualizerLib.Exceptions
{
    /// <summary>
    /// Ошибка формата эксель файла
    /// </summary>
    internal class NotExcelFileException : StatisticVisualizerException
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public NotExcelFileException(string fileName, string russianMessage = null) : base(russianMessage = $"{fileName} не эксель файл") { }
    }
}
