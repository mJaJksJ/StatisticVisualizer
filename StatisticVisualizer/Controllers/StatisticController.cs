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
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="isOnlyMale">Фильтрация по полу (null - Ж+М, true - М, false - Ж)</param>
        /// <returns></returns>
        public IActionResult Index(int pageNumber = 0, bool? isOnlyMale = null)
        {
            var people = _context.People
                .Include(_ => _.City)
                .OrderByDescending(_ => _.Id)
                .AsQueryable();

            if (isOnlyMale is not null)
            {
                people = people.Where(_ => _.IsMale == isOnlyMale);
            }

            var peopleModel = people
                .Skip(PageInfo.PageSize * pageNumber)
                .Take(PageInfo.PageSize)
                .Select(_ => new PersonModel
                {
                    Name = _.Name,
                    City = _.City.Name,
                    IsMale = _.IsMale,
                    Age = _.Age
                });

            return View(new StatisticModel
            {
                People = peopleModel,
                PageInfo = new PageInfo
                {
                    TotalItems = people.Count(),
                    PageNumber = pageNumber,
                    TotalPages = (int)Math.Ceiling((decimal)people.Count() / PageInfo.PageSize) - 1
                },
                MenCount = _context.People.Count(_ => _.IsMale),
                WomenCount = _context.People.Count(_ => !_.IsMale),
                IsOnlyMale = isOnlyMale
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
