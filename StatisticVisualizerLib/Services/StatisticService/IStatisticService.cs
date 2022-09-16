using StatisticVisualizer.Models;

namespace StatisticVisualizerLib.Services.StatisticService
{
    /// <summary>
    /// Сервис получения статистики из бд
    /// </summary>
    public interface IStatisticService
    {
        /// <summary>
        /// Получить информацию по статистике из бд
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="isOnlyMale">Фильтрация по полу (null - Ж+М, true - М, false - Ж)</param>
        /// <param name="error">Ошибка</param>
        public StatisticModel GetStatistic(int pageNumber, bool? isOnlyMale, string error = "");
    }
}
