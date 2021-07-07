using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOefening.ServiceLayer;
using ProjectOefening.ServiceLayer.ViewModels;
using ProjectOefening_1_Web___Media_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IGeneralService  _generalService;

        public FilmController(IFilmService filmService, IGeneralService generalService)
        {
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateFilm()
        {
            SetViewData();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFilm([FromForm] FilmViewModel filmViewModel) 
        {
            SetViewData();

            await _filmService.CreateFilmAsync(filmViewModel, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction(nameof(ShowFilms));
        }

        [HttpGet]
        [Route("EditFilm/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> EditFilm(int id)
        {
            SetViewData();

            return View(await _filmService.GetVMFromIDAsync(id));
        }

        [HttpPost]
        [Route("EditFilm/{id}")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> EditFilm([FromForm] FilmViewModel filmViewModel)
        {
            SetViewData();

            await _filmService.EditFilmAsync(filmViewModel);
            return RedirectToAction(nameof(ShowFilms));
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowFilms()
        {
           
            return View(await _filmService.ShowFilmViewmodelsAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowMyFilms()
        {

            return View(await _filmService.ShowMyFilmViewmodelsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [Route("DeleteFilm/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            await _filmService.DeleteFilmAsync(id);
            return RedirectToAction(nameof(ShowFilms));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult CreateArtistAsync([FromForm] ArtistViewModel artistViewModel)
        {
            _generalService.CreateArtist(artistViewModel);
            return RedirectToAction(nameof(CreateFilm));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult CreateGenre([FromForm] GenreViewModel genreViewModel)
        {
            _generalService.CreateGenre(genreViewModel);
            return RedirectToAction(nameof(CreateFilm));
        }

        public void SetViewData()
        {
            var directors = _generalService.ShowAllArtists();
            ViewData["Directors"] = directors.Where(x => x.ArtistType.ToString().Equals("Director")).ToList();
            var actors = _generalService.ShowAllArtists();
            ViewData["Actors"] = actors.Where(x => x.ArtistType.ToString().Equals("Actor")).ToList();
            var genres =  _generalService.ShowAllGenres();
            ViewData["Genres"] = genres.Where(x => x.Genretype.ToString().Equals("Cinema")).ToList();
        }
    }
}
