using Microsoft.AspNetCore.Mvc;

namespace StatisticVisualizer.Controllers
{
    /// <summary>
    /// Контроллер страницы загрузки файла
    /// </summary>
    public class UploadController : Controller
    {
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
            return Ok();
        }
    }
}
