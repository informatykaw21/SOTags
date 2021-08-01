using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SOTags.MVC.Models;
using SOTags.MVC.Models.ViewModels;
using SOTags.MVC.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SOTags.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStackOverflowService _soService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStackOverflowService soService, ILogger<HomeController> logger)
        {
            _soService = soService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            TagInfosViewModel viewModel;
            try
            {
                var apiResult = await _soService.GetTopMostPopularTags(1000);
                viewModel = new TagInfosViewModel(apiResult);
            }
            catch
            {
                viewModel = null;
            }
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}