using Microsoft.AspNetCore.Mvc;
using ProjectOefening.ServiceLayer;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class TVSerieController : Controller
    {
        private readonly TVSerieService _tvSerieService;
        private readonly IGeneralService _generalService;
        public TVSerieController(TVSerieService tvSerieService, IGeneralService generalService)
        {
            _tvSerieService = tvSerieService ?? throw new ArgumentNullException(nameof(tvSerieService));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateTVSerie()
        {
            ViewData["Actors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Actor")).ToList();
            ViewData["Directors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Director")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Cinema")).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTVSerie([FromForm] TVSerieViewModel tVSerieViewModel)
        {
            ViewData["Actors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Actor")).ToList();
            ViewData["Directors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Director")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Cinema")).ToList();
            _tvSerieService.CreateTVSerie(tVSerieViewModel);
            return RedirectToAction(nameof(ShowTVSeries));
        }

        [HttpGet]
        [Route("EditTVSerie/{id}")]
        public ActionResult EditTVSerie(int id)
        {
            ViewData["Actors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Actor")).ToList();
            ViewData["Directors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Director")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Cinema")).ToList();
            var test = _tvSerieService.GetVMFromID(id);
            return View(test);
        }

        [HttpPost]
        [Route("EditTVSerie/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditTVSerie([FromForm] TVSerieViewModel tvSerieViewModel)
        {
            ViewData["Actors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Actor")).ToList();
            ViewData["Directors"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("Director")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Cinema")).ToList();
            _tvSerieService.EditTVSerie(tvSerieViewModel);
            return RedirectToAction(nameof(ShowTVSeries));
        }

        //[HttpDelete]
        [Route("DeleteTVSerie/{id}")]
        public ActionResult DeleteTVSerie(int id)
        {
            _tvSerieService.DeleteTVSerie(id);
            return RedirectToAction(nameof(ShowTVSeries));
        }
        public ActionResult ShowTVSeries()
        {
            return View(_tvSerieService.ShowTVSerieViewModels());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([FromForm] ArtistViewModel artistViewModel)
        {
            _generalService.CreateArtist(artistViewModel);
            return RedirectToAction(nameof(CreateTVSerie));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre([FromForm] GenreViewModel genreViewModel)
        {
            _generalService.CreateGenre(genreViewModel);
            return RedirectToAction(nameof(CreateTVSerie));
        }
    }
}
