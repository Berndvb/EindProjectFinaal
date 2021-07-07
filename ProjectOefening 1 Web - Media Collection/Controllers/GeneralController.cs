using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOefening.Domain;
using ProjectOefening.ServiceLayer;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IGeneralService _generalService;
        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CreateArtist()
        {
            //ViewData["ArtistTypes"] = _extraService.ShowArtistTypes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateArtist([FromForm] ArtistViewModel artistViewModel)
        {
            //ViewData["ArtistTypes"] = _extraService.ShowArtistTypes();
            _generalService.CreateArtist(artistViewModel);
            return RedirectToAction(nameof(ShowArtists));
        }

        [AllowAnonymous]
        public ActionResult CreateGenre()
        {
            //ViewData["GenreTypes"] = _extraService.ShowGenreTypes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateGenre([FromForm] GenreViewModel genreViewModel)
        {
            //ViewData["GenreTypes"] = _extraService.ShowGenreTypes();
            _generalService.CreateGenre(genreViewModel);
            return RedirectToAction(nameof(ShowGenres));
        }

        [HttpGet]
        [Route("EditArtist/{id}")]
        [AllowAnonymous]
        public ActionResult EditArtist(int id)
        {
            ViewData["Artists"] = _generalService.ShowAllArtists();
            ViewData["Genres"] = _generalService.ShowAllGenres();
            return View(_generalService.GetArtistVMFromID(id));
        }

        [HttpPost]
        [Route("EditArtist/{id}")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult EditArtist([FromForm] ArtistViewModel artistViewModel)
        {
            ViewData["Artists"] = _generalService.ShowAllArtists();
            ViewData["Genres"] = _generalService.ShowAllGenres();
            _generalService.Edit(artistViewModel);
            return RedirectToAction(nameof(ShowArtists));
        }


        [HttpGet]
        [Route("EditGenre/{id}")]
        [AllowAnonymous]
        public ActionResult EditGenre(int id)
        {
            ViewData["Artists"] = _generalService.ShowAllArtists();
            ViewData["Genres"] = _generalService.ShowAllGenres();
            return View(_generalService.GetGenreVMFromID(id));
        }

        [HttpPost]
        [Route("EditGenre/{id}")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult EditGenre([FromForm] GenreViewModel genreViewModel)
        {
            ViewData["Artists"] = _generalService.ShowAllArtists();
            ViewData["Genres"] = _generalService.ShowAllGenres();
            _generalService.Edit(genreViewModel);
            return RedirectToAction(nameof(ShowGenres));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShowArtists()
        {
            return View(_generalService.ShowAllArtists());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShowGenres()
        {
            return View(_generalService.ShowAllGenres());
        }

        [Route("DeleteArtist/{id}")]
        [AllowAnonymous]
        public ActionResult DeleteArtist(int id)
        {
            _generalService.DeleteArtist(id);
            return RedirectToAction(nameof(ShowArtists));
        }

        [Route("DeleteGenre/{id}")]
        [AllowAnonymous]
        public ActionResult DeleteGenre(int id)
        {
            _generalService.DeleteGenre(id);
            return RedirectToAction(nameof(ShowGenres));
        }
    }
}
