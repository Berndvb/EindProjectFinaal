using Microsoft.AspNetCore.Mvc;
using ProjectOefening.ServiceLayer;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicService _musicService;
        private readonly IGeneralService _generalService;
        public MusicController(MusicService musicService, IGeneralService generalService)
        {
            _musicService = musicService ?? throw new ArgumentNullException(nameof(musicService));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateMusic()
        {
            ViewData["MusicArtists"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("MusicArtist")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Music")).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMusic([FromForm] MusicViewModel musicViewModel)
        {
            ViewData["MusicArtists"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("MusicArtist")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Music")).ToList();
            _musicService.CreateMusic(musicViewModel);
            return RedirectToAction(nameof(ShowMusic));
        }

        [HttpGet]
        [Route("EditMusic/{id}")]
        public ActionResult EditMusic(int id)
        {
            ViewData["MusicArtists"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("MusicArtist")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Music")).ToList();
            return View(_musicService.GetVMFromID(id));
        }

        [HttpPost]
        [Route("EditMusic/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditMusic([FromForm] MusicViewModel musicViewModel)
        {
            ViewData["MusicArtists"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("MusicArtist")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Music")).ToList();
            _musicService.EditMusic(musicViewModel);
            return RedirectToAction(nameof(ShowMusic));
        }

        //[HttpDelete]
        [Route("DeleteMusic/{id}")]
        public ActionResult DeleteMusic(int id)
        {
            _musicService.DeleteMusic(id);
            return RedirectToAction(nameof(ShowMusic));
        }

        public ActionResult ShowMusic()
        {
            return View(_musicService.ShowMusicViewmodels());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([FromForm] ArtistViewModel artistViewModel)
        {
            _generalService.CreateArtist(artistViewModel);
            return RedirectToAction(nameof(CreateMusic));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre([FromForm] GenreViewModel genreViewModel)
        {
            _generalService.CreateGenre(genreViewModel);
            return RedirectToAction(nameof(CreateMusic));
        }
    }
}
