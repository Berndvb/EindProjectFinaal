using Microsoft.EntityFrameworkCore;
using ProjectOefening.Domain;
using ProjectOefening.Repository;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ReviewService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public void CreateReview(ReviewViewModel reviewVM)
        {
            var review = new Review()
            {
                ReviewText = reviewVM.ReviewText,
                Score = reviewVM.Score,
                //Owner = reviewVM.Owner,
                MediaItemId = reviewVM.MediaItemId
            };
            var mediaReviews = _applicationDbContext.Medias.Include(x => x.Reviews).FirstOrDefault(x => x.Id.Equals(reviewVM.MediaItemId)).Reviews;
            if (mediaReviews == null)
            {
                mediaReviews = new();
            }
            mediaReviews.Add(review);
            _applicationDbContext.Reviews.Add(review);
            _applicationDbContext.SaveChanges();
        }
        public void EditReview(ReviewViewModel reviewVM)
        {
            var foundReview = _applicationDbContext.Reviews.FirstOrDefault(x => x.Id.Equals(reviewVM.Id));

            foundReview.ReviewText = reviewVM.ReviewText; 
            foundReview.Score = reviewVM.Score;
            //foundReview.Owner = reviewVM.Owner;
            foundReview.MediaItemId = reviewVM.MediaItemId;

            _applicationDbContext.SaveChanges();
        }
        public void DeleteReview(int id)
        {
            _applicationDbContext.Reviews.Remove(
              _applicationDbContext.Reviews.FirstOrDefault(review => review.Id.Equals(id)));
            _applicationDbContext.SaveChanges();
        }
        public List<ReviewViewModel> ShowReviewViewmodels(int id)// wat haal je op? Lijst van Reviews gekoppeld aan die mediaitem, of eerder alles review objecten met die Mediaitem-id?
        {

            List<ReviewViewModel> ReviewVMs = new();
            var reviews = _applicationDbContext.Reviews.Where(x => x.MediaItemId.Equals(id));
            if (reviews != null)
            {
                foreach (var review in reviews)
                {
                    ReviewVMs.Add(new ReviewViewModel
                    {
                        Id = review.Id,
                        ReviewText = review.ReviewText,
                        //Owner = review.Owner,
                        Score = review.Score,
                        MediaItemId = review.MediaItemId
                    });
                }
            }

            return ReviewVMs;
        }

        public ReviewViewModel GetVMFromID(int id)
        {
            var reviewFound = _applicationDbContext.Reviews.FirstOrDefault(review => review.Id.Equals(id));
            var reviewVM = new ReviewViewModel()
            {
                Id = reviewFound.Id,
                ReviewText = reviewFound.ReviewText,
                //Owner = reviewFound.Owner,
                Score = reviewFound.Score,
                MediaItemId = reviewFound.MediaItemId
            };
            return reviewVM;
        }
    }
}
