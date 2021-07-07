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
    public class PodcastService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IGeneralService _generalService;
        public PodcastService(ApplicationDbContext applicationDbContext, IGeneralService generalService)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }

        public void CreatePodcast(PodcastViewModel podcastViewModel)
        {
            var podcast = new Podcast()
            {
                Title = podcastViewModel.Title,
                ReleaseDate = podcastViewModel.ReleaseDate,
                Duration = podcastViewModel.Duration,
                Url = podcastViewModel.Url,
                Guests = (List<Artist>)_generalService.GetArtistsFromVM(podcastViewModel.Guests),
                Genres = (List<Genre>)_generalService.GetGenresFromVM(podcastViewModel.Genres),
                Hosts = (List<Artist>)_generalService.GetArtistsFromVM(podcastViewModel.Hosts)
            };

            _applicationDbContext.Medias.Add(podcast);
            _applicationDbContext.SaveChanges();
        }
        public void EditPodcast(PodcastViewModel podcastViewModel)
        {
            var podcastOld = _applicationDbContext.Medias
                .OfType<Podcast>().Include(x => x.Guests).Include(x => x.Genres).Include(x => x.Hosts)
                .FirstOrDefault(x => x.Id.Equals(podcastViewModel.Id));

            podcastOld.Title = podcastViewModel.Title;
            podcastOld.ReleaseDate = podcastViewModel.ReleaseDate;
            podcastOld.Duration = podcastViewModel.Duration;
            podcastOld.Url = podcastViewModel.Url;
            podcastOld.Guests = (List<Artist>)_generalService.GetArtistsFromVM(podcastViewModel.Guests);
            podcastOld.Genres = (List<Genre>)_generalService.GetGenresFromVM(podcastViewModel.Genres);
            podcastOld.Hosts = (List<Artist>)_generalService.GetArtistsFromVM(podcastViewModel.Hosts);

            _applicationDbContext.SaveChanges();
        }
        public void DeletePodcast(int id)
        {
            _applicationDbContext.Medias.Remove(
                _applicationDbContext.Medias.Include(podcast => podcast.Reviews)
                .Include(podcast => (podcast as Podcast).Guests)
                .Include(podcast => (podcast as Podcast).Hosts)
                .FirstOrDefault(podcast => podcast.Id.Equals(id)));

            _applicationDbContext.SaveChanges();
        }

        public ShowPodcastViewModel GetVMFromID(int id)
        {
            var podcastFound = _applicationDbContext.Medias.OfType<Podcast>().Include(x => x.Hosts).Include(x => x.Guests).Include(x => x.Genres).FirstOrDefault(podcast => podcast.Id.Equals(id));
            var podcastVM = new ShowPodcastViewModel()
            {
                Id = podcastFound.Id,
                Duration = podcastFound.Duration,
                Url = podcastFound.Url,
                ReleaseDate = podcastFound.ReleaseDate,
                Title = podcastFound.Title,
                Reviews = podcastFound.Reviews,
                Hosts = podcastFound.Hosts,
                Guests = podcastFound.Guests,
                Genres = podcastFound.Genres
            };
            return podcastVM;
        }


        public List<ShowPodcastViewModel> ShowPodcastViewmodels()
        {
            List<ShowPodcastViewModel> podcastViewmodels = new();

            foreach (var podcast in _applicationDbContext.Medias.OfType<Podcast>().Include(x => x.Guests).Include(x => x.Genres).Include(x => x.Hosts))
            {
                podcastViewmodels.Add(new ShowPodcastViewModel
                {
                    Id = podcast.Id,
                    Title = podcast.Title,
                    ReleaseDate = podcast.ReleaseDate,
                    Duration = podcast.Duration,
                    Url = podcast.Url,
                    Guests = podcast.Guests,
                    Reviews = podcast.Reviews,
                    Genres = podcast.Genres,
                    Hosts = podcast.Hosts
                });
            }
            return podcastViewmodels;
        }
    }
}

