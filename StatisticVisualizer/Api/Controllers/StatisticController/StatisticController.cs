using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatisticVisualizer.Models;
using StatisticVisualizerLib.Services.ExcelFileService;
using StatisticVisualizerLib.Services.StatisticService;

namespace StatisticVisualizer.Api.Controllers.StatisticController
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
        [HttpPost("~/api/v1/statistic"), AllowAnonymous]
        [ProducesResponseType(typeof(StatisticModel), 200)]
        public IActionResult GetStatistic(int pageNumber = 0, bool? isOnlyMale = null)
        {
            return Ok(_statisticService.GetStatistic(pageNumber, isOnlyMale));
        }
    }
}
