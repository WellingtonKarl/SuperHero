using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using SuperHero.Domain.Interfaces;
using SuperHero.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMarvelService _imarvelService;
        private const string _proporcion = "portrait_uncanny.";

        public HomeController(ILogger<HomeController> logger, IMarvelService marvelService)
        {
            _logger = logger;
            _imarvelService = marvelService;
        }

        public async Task<IActionResult> Index()
        {
            var characters = await _imarvelService.GetAllCharacters();
            var charactersViewModel = new CharactersViewModel
            {
                NameSuperHero = characters.data.results.Select(c => new SelectListItem
                {
                    Value = c.id,
                    Text = c.name
                }),
            };

            return View(charactersViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> LoadInformationsSuperHero(int id)
        {
            var character = await _imarvelService.GetCharacter(id);

            var comicItens = character.data.results.Select(r => r.comics).Select(s => s.items).FirstOrDefault();

            var listitem = comicItens.Select(i => new SelectListItem
            {
                Value = i.resourceURI,
                Text = i.name
            });

            var thumbnail = character.data.results.Select(r => r.thumbnail).FirstOrDefault();

            ViewBag.FrontCover = string.Concat(thumbnail.path, "/", _proporcion, thumbnail.extension);
            ViewBag.Description = character.data.results.Select(r => r.description).FirstOrDefault();

            var partialCombo = await ConverterHelper.RenderViewAsync(this, "Compenents/_ComboComicsComponent", listitem, true);
            var partialImage = await ConverterHelper.RenderViewAsync(this, "Compenents/_ImageCharacters", ViewBag.FrontCover, true);
            var partialDescription = await ConverterHelper.RenderViewAsync(this, "Compenents/_DescriptionComponent", ViewBag.Description, true);

            return Json(
                new
                {
                    combo = partialCombo,
                    image = partialImage,
                    description = partialDescription
                });
        }

        public async Task<IActionResult> LoadInformationsHQs(string url)
        {
            var comics = await _imarvelService.GetComicCharacter(url);

            var thumbnail = comics.data.results.Select(r => r.thumbnail).FirstOrDefault();

            var path = string.Concat(thumbnail.path, "/", _proporcion, thumbnail.extension);
            ViewBag.Description = comics.data.results.Select(r => r.description).FirstOrDefault();

            var patialImageComics = await ConverterHelper.RenderViewAsync(this, "Compenents/_ImageComic", path, true);

            return Json(new { imageComic = patialImageComics, description = ViewBag.Description });
        }
    }
}
