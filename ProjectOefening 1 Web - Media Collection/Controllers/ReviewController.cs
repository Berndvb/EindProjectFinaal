using Microsoft.AspNetCore.Mvc;
using ProjectOefening.ServiceLayer;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOefening_1_Web___Media_Collection.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        private readonly IGeneralService _generalService;


        public ReviewController(ReviewService reviewService, IGeneralService generalService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("CreateReview/{id}")]
        public ActionResult CreateReview(int id)
        {
            //ViewData["MediaType"] = _extraService.GetMediaType(id);
            ViewData["MediaId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreateReview/{id}")]
        public ActionResult CreateReview([FromForm] ReviewViewModel reviewViewModel, int id)
        {
            //ViewData["MediaType"] = _extraService.GetMediaType(id);
            ViewData["MediaId"] = id;
            reviewViewModel.MediaItemId = _generalService.GetMediaItemFromID(id).Id;
            _reviewService.CreateReview(reviewViewModel);
            return RedirectToAction("ShowReviews", "Review", new { Id = reviewViewModel.MediaItemId });
        }

        [HttpGet]
        [Route("EditReview/{id}")]
        public ActionResult EditReview(int id)
        {

            return View(_reviewService.GetVMFromID(id));
        }

        [HttpPost]
        [Route("EditReview/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview([FromForm] ReviewViewModel reviewViewModel) // mediaitem is null, dus er niet aan gelinkt, maw = kan niet terugkeren naar show reviews van die media
        {

            _reviewService.EditReview(reviewViewModel);
            return RedirectToAction("ShowReviews", "Review", new { Id = reviewViewModel.MediaItemId});
        }

        [Route("Review/ShowReviews/{id}")]
        public ActionResult ShowReviews(int id)
        {
            ViewData["MediaType"] = _generalService.GetMediaType(id);
            ViewData["MediaId"] = id;
            return View(_reviewService.ShowReviewViewmodels(id));
        }

        //[HttpDelete] ?????
        [Route("DeleteReview/{id}")]
        public ActionResult DeleteReview(int id)
        {
            var test = _reviewService.GetVMFromID(id).MediaItemId;
            _reviewService.DeleteReview(id);
            
            return RedirectToAction("ShowReviews", "Review", new { id = test });
        }
    }
}
