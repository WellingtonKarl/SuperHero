using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SuperHero.Domain.Interfaces;
using SuperHero.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMarvelService _imarvelService;
        private const string _proporcion = "standard_small";

        public HomeController(ILogger<HomeController> logger, IMarvelService marvelService)
        {
            _logger = logger;
            _imarvelService = marvelService;
        }

        public async Task<IActionResult> Index()
        {
            var characters = await _imarvelService.GetAllCharacters();
            var charactersViewModel = new CharactersViewModel();

            charactersViewModel.NameSuperHero = characters.data.results.Select(c => new SelectListItem
            {
                Value = c.id,
                Text = c.name
            });

            return View(charactersViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LoadImageSuperHero(int id)
        {
            return Json(new { success = true, data = id });
        }
    }
}
