using GoogleReCaptcha.Models;
using GoogleReCaptcha.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoogleReCaptcha.Controllers
{
    public class HomeController : Controller
    {
        private readonly GoogleReCaptchaService _service;

        public HomeController(GoogleReCaptchaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            var resultOfVerification = await _service.GetResultOfVerification(person.Token);

            if (!resultOfVerification.Success && resultOfVerification.Score <= 0.5)
            {
                ModelState.AddModelError("", "Sorry, you aren't human! :(");
            }

            return View(nameof(Index));
        }
    }
}