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
    public class TVSerieService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IGeneralService _generalService;
        public TVSerieService(ApplicationDbContext applicationDbContext, IGeneralService generalService)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }
        public void CreateTVSerie(TVSerieViewModel tvSerieViewModel)
        {
            var tvSerie = new TVSerie()
            {
                Title = tvSerieViewModel.Title,
                ReleaseDate = tvSerieViewModel.ReleaseDate,
                Duration = tvSerieViewModel.Duration,
                Url = tvSerieViewModel.Url,
                Actors = (List<Artist>)_generalService.GetArtistsFromVM(tvSerieViewModel.Actors),
                Genres = (List<Genre>)_generalService.GetGenresFromVM(tvSerieViewModel.Genres),
                Episodes = tvSerieViewModel.Episodes,
                Seasons = tvSerieViewModel.Seasons,
                Directors = (List<Artist>)_generalService.GetArtistsFromVM(tvSerieViewModel.Directors)
            };

            _applicationDbContext.Medias.Add(tvSerie);
            //LinkWithGenresArtists(tvSerieViewModel, tvSerie);
            _applicationDbContext.SaveChanges();
        }
        public void EditTVSerie(TVSerieViewModel tvSerieViewModel) // ref type
        {
            var tvSerieOld = _applicationDbContext.Medias
                .OfType<TVSerie>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors)
                .FirstOrDefault(x => x.Id.Equals(tvSerieViewModel.Id));

            //DeleteExistingLinks(filmOld as Film); // ??? - filmOld zogezegd geen artists

            tvSerieOld.Title = tvSerieViewModel.Title;
            tvSerieOld.ReleaseDate = tvSerieViewModel.ReleaseDate;
            tvSerieOld.Duration = tvSerieViewModel.Duration;
            tvSerieOld.Url = tvSerieViewModel.Url;
            tvSerieOld.Actors = (List<Artist>)_generalService.GetArtistsFromVM(tvSerieViewModel.Actors);
            tvSerieOld.Genres = (List<Genre>)_generalService.GetGenresFromVM(tvSerieViewModel.Genres);
            tvSerieOld.Directors = (List<Artist>)_generalService.GetArtistsFromVM(tvSerieViewModel.Directors);
            (tvSerieOld as TVSerie).Seasons = tvSerieViewModel.Seasons;
            (tvSerieOld as TVSerie).Episodes = tvSerieViewModel.Episodes;

            //LinkWithGenresArtists(filmViewModel, (filmOld as Film)); // ????
            _applicationDbContext.SaveChanges();
        }
        public ShowTVSerieViewModel GetVMFromID(int id)
        {
            var tvSerieFound = _applicationDbContext.Medias.OfType<TVSerie>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors).FirstOrDefault(tvSerie => tvSerie.Id.Equals(id));
            var tvSerieVM = new ShowTVSerieViewModel()
            {
                Id = tvSerieFound.Id,
                Duration = tvSerieFound.Duration,
                Url = tvSerieFound.Url,
                ReleaseDate = tvSerieFound.ReleaseDate,
                Title = tvSerieFound.Title,
                Reviews = tvSerieFound.Reviews,
                Directors = tvSerieFound.Directors,
                Episodes = tvSerieFound.Episodes,
                Seasons = tvSerieFound.Seasons,
                Actors = tvSerieFound.Actors,
                Genres = tvSerieFound.Genres,
            };
            return tvSerieVM;
        }


        public List<ShowTVSerieViewModel> ShowTVSerieViewModels()
        {
            List<ShowTVSerieViewModel> tvSerieViewModel = new();

            foreach (var tvSerie in _applicationDbContext.Medias.OfType<TVSerie>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors))
            {
                tvSerieViewModel.Add(new ShowTVSerieViewModel
                {
                    Id = tvSerie.Id,
                    Title = tvSerie.Title,
                    ReleaseDate = tvSerie.ReleaseDate,
                    Duration = tvSerie.Duration,
                    Url = tvSerie.Url,
                    Actors = tvSerie.Actors,
                    Reviews = tvSerie.Reviews,
                    Genres = tvSerie.Genres,
                    Episodes = tvSerie.Episodes,
                    Seasons = tvSerie.Seasons,
                    Directors = tvSerie.Directors
                });
            }
            return tvSerieViewModel;
        }

        public void DeleteTVSerie(int id)
        {
            _applicationDbContext.Medias.Remove(
                _applicationDbContext.Medias.Include(tvSerie => tvSerie.Reviews)
                .Include(tvSerie => (tvSerie as TVSerie).Actors)
                .Include(tvSerie => (tvSerie as TVSerie).Directors)
                .FirstOrDefault(tvSerie => tvSerie.Id.Equals(id)));

            _applicationDbContext.SaveChanges();
        }
    }
}

