using Microsoft.AspNetCore.Mvc;
using StatisticVisualizer.Models;
using StatisticVisualizerLib.Services.ExcelFileService;

namespace StatisticVisualizer.Controllers
{
    /// <summary>
    /// Контроллер страницы загрузки файла
    /// </summary>
    public class UploadController : Controller
    {
        private readonly IExcelFileService _excelFileService;

        /// <summary>
        /// .ctor
        /// </summary>
        public UploadController(IExcelFileService excelFileService)
        {
            _excelFileService = excelFileService;
        }

        /// <summary>
        /// Страница загрузки файла
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Получение файла
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var (total, succes, error) = _excelFileService.UploadToDb(file);
            return View(new UploadModel
            {
                TotalProcessedRows = total,
                SuccesedProcessedRows = succes,
                FileName = file.FileName,
                Error = error
            });
        }
    }
}
