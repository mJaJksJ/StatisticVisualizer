using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticVisualizer.Models;
using StatisticVisualizerLib.Database;
using StatisticVisualizerLib.Services.ExcelFileService;

namespace StatisticVisualizer.Controllers
{
    /// <summary>
    /// Контроллер отображающий статистику по информации из бд
    /// </summary>
    public class StatisticController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IExcelFileService _excelFileService;

        /// <summary>
        /// .ctor
        /// </summary>
        public StatisticController(DatabaseContext context, IExcelFileService excelFileService)
        {
            _context = context;
            _excelFileService = excelFileService;
        }

        /// <summary>
        /// Страница статистики
        /// </summary>
        public IActionResult Index(int pageNumber = 0)
        {
            var people = _context.People
                .Include(_ => _.City)
                .OrderByDescending(_ => _.Id);

            return View(new StatisticModel
            {
                People = people
                .Skip(PageInfo.PageSize * pageNumber)
                .Take(PageInfo.PageSize)
                .Select(_ => new PersonModel
                {
                    Name = _.Name,
                    City = _.City.Name,
                    IsMale = _.IsMale,
                    Age = _.Age
                }),
                PageInfo = new PageInfo
                {
                    TotalItems = _context.People.Count(),
                    PageNumber = pageNumber,
                },
                MenCount = _context.People.Count(_ => _.IsMale),
                WomenCount = _context.People.Count(_ => !_.IsMale)
            });
        }

        /// <summary>
        /// Получение файла
        /// </summary>
        /// <param name="file">Загружаемый файл</param>
        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            _excelFileService.UploadToDb(file);
            return Redirect("/Statistic");
        }
    }
}
