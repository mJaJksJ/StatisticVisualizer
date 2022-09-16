using Microsoft.AspNetCore.Mvc;
using StatisticVisualizerLib.Services.ExcelFileService;
using StatisticVisualizerLib.Services.StatisticService;

namespace StatisticVisualizer.Controllers
{
    /// <summary>
    /// Контроллер отображающий статистику по информации из бд
    /// </summary>
    public class StatisticController : Controller
    {
        private readonly IExcelFileService _excelFileService;
        private readonly IStatisticService _statisticService;

        /// <summary>
        /// .ctor
        /// </summary>
        public StatisticController(IExcelFileService excelFileService, IStatisticService statisticService)
        {
            _excelFileService = excelFileService;
            _statisticService = statisticService;
        }

        /// <summary>
        /// Страница статистики
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="isOnlyMale">Фильтрация по полу (null - Ж+М, true - М, false - Ж)</param>
        public IActionResult Index(int pageNumber = 0, bool? isOnlyMale = null)
        {
            return View(_statisticService.GetStatistic(pageNumber, isOnlyMale));
        }

        /// <summary>
        /// Получение файла
        /// </summary>
        /// <param name="file">Загружаемый файл</param>
        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var (_, _, _error) = _excelFileService.UploadToDb(file);
            return Redirect("/Statistic");
        }
    }
}
