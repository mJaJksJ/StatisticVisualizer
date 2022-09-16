using Microsoft.EntityFrameworkCore;
using Serilog;
using StatisticVisualizer.Models;
using StatisticVisualizerLib.Database;

namespace StatisticVisualizerLib.Services.StatisticService
{
    /// <inheritdoc cref="IStatisticService"/>
    public class StatisticService : IStatisticService
    {
        private readonly DatabaseContext _context;

        private static readonly ILogger Log = Serilog.Log.ForContext<StatisticService>();

        /// <summary>
        /// .ctor
        /// </summary>
        public StatisticService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public StatisticModel GetStatistic(int pageNumber, bool? isOnlyMale, string error = "")
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

            return new StatisticModel
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
                IsOnlyMale = isOnlyMale,
                Error = error
            };
        }
    }
}
