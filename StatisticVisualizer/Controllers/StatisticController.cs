using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticVisualizer.Models;
using StatisticVisualizerLib.Database;

namespace StatisticVisualizer.Controllers
{
    /// <summary>
    /// Контроллер отображающий статистику по информации из бд
    /// </summary>
    public class StatisticController : Controller
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        public StatisticController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Страница статистики
        /// </summary>
        public IActionResult Index(int pageNumber = 0)
        {
            var people = _context.People
                .Include(_ => _.City)
                .OrderBy(_ => _.Id)
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
                People = people,
                PageInfo = new PageInfo
                {
                    TotalItems = _context.People.Count(),
                    PageNumber = pageNumber,
                }
            });
        }
    }
}
