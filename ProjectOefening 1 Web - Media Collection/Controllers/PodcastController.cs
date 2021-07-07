using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectOefening.ServiceLayer;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class PodcastController : Controller
    {
        private readonly PodcastService _podcastService;
        private readonly IGeneralService _generalService;
        public PodcastController(PodcastService podcastService, IGeneralService generalService)
        {
            _podcastService = podcastService ?? throw new ArgumentNullException(nameof(podcastService));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CreatePodcast()
        {
            ViewData["Hosts"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastHost")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Podcast")).ToList();
            ViewData["Guests"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastGuest")).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreatePodcast([FromForm] PodcastViewModel podcastViewModel)
        {
            ViewData["Hosts"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastHost")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Podcast")).ToList();
            ViewData["Guests"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastGuest")).ToList();
            _podcastService.CreatePodcast(podcastViewModel);
            return RedirectToAction(nameof(ShowPodcasts));
        }

        [HttpGet]
        [Route("EditPodcast/{id}")]
        [AllowAnonymous]
        public ActionResult EditPodcast(int id)
        {
            ViewData["Hosts"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastHost")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Podcast")).ToList();
            ViewData["Guests"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastGuest")).ToList();
            return View(_podcastService.GetVMFromID(id));
        }

        [HttpPost]
        [Route("EditPodcast/{id}")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult EditPodcast([FromForm] PodcastViewModel podcastViewModel)
        {
            ViewData["Hosts"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastHost")).ToList();
            ViewData["Genres"] = _generalService.ShowAllGenres().Where(x => x.Genretype.ToString().Equals("Podcast")).ToList();
            ViewData["Guests"] = _generalService.ShowAllArtists().Where(x => x.ArtistType.ToString().Equals("PodcastGuest")).ToList();
            _podcastService.EditPodcast(podcastViewModel);
            return RedirectToAction(nameof(ShowPodcasts));
        }

        //[HttpDelete]
        [Route("DeletePodcast/{id}")]
        [AllowAnonymous]
        public ActionResult DeletePodcast(int id)
        {
            _podcastService.DeletePodcast(id);
            return RedirectToAction(nameof(ShowPodcasts));
        }

        [AllowAnonymous]
        public ActionResult ShowPodcasts()
        {
            return View(_podcastService.ShowPodcastViewmodels());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateArtist([FromForm] ArtistViewModel artistViewModel)
        {
            _generalService.CreateArtist(artistViewModel);
            return RedirectToAction(nameof(CreatePodcast));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateGenre([FromForm] GenreViewModel genreViewModel)
        {
            _generalService.CreateGenre(genreViewModel);
            return RedirectToAction(nameof(CreatePodcast));
        }
    }
}
