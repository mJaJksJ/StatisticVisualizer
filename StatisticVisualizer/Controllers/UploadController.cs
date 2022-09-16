using Microsoft.AspNetCore.Mvc;

namespace StatisticVisualizer.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            return Ok();
        }
    }
}
