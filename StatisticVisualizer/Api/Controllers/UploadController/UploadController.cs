using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatisticVisualizer.Models;
using StatisticVisualizerLib.Services.ExcelFileService;

namespace StatisticVisualizer.Api.Controllers.UploadController
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
        /// Получение файла
        /// </summary>
        /// <param name="file">Загружаемый файл</param>
        [HttpPost("~/api/v1/upload"), AllowAnonymous]
        [ProducesResponseType(typeof(UploadModel), 200)]
        public IActionResult LoadFile(IFormFile file)
        {
            var (total, succes, error) = _excelFileService.UploadToDb(file);

            return Ok(new UploadModel
            {
                TotalProcessedRows = total,
                SuccesedProcessedRows = succes,
                FileName = file?.FileName,
                Error = error
            });
        }
    }
}
