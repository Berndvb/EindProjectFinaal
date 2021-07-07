using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectOefening.Domain;
using ProjectOefening.Domain.Identity;
using ProjectOefening.Repository;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IGeneralService _generalService;
        private readonly UserManager<ApplicationUser> _userManager;
        public FilmService(ApplicationDbContext applicationDbContext, IGeneralService generalService, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task CreateFilmAsync(FilmViewModel filmViewModel, string userId) 
        {
            var film = new Film()
            {
                Title = filmViewModel.Title,
                ReleaseDate = (DateTime)filmViewModel.ReleaseDate,
                Duration = (int)filmViewModel.Duration,
                Url = filmViewModel.Url,
                Actors = (List<Artist>)_generalService.GetArtistsFromVM(filmViewModel.Actors),
                Genres = (List<Genre>)_generalService.GetGenresFromVM(filmViewModel.Genres),
                Directors = (List<Artist>)_generalService.GetArtistsFromVM(filmViewModel.Directors),
                UserId = userId
            };

            await _applicationDbContext.Medias.AddAsync(film);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task EditFilmAsync(FilmViewModel filmViewModel)
        {
            var filmOld = _applicationDbContext.Medias
                .OfType<Film>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors)
                .FirstOrDefault(x => x.Id.Equals(filmViewModel.Id));

            filmOld.Title = filmViewModel.Title;
            filmOld.ReleaseDate = filmViewModel.ReleaseDate;
            filmOld.Duration = filmViewModel.Duration;
            filmOld.Url = filmViewModel.Url;
            filmOld.Actors = (List<Artist>)_generalService.GetArtistsFromVM(filmViewModel.Actors);
            filmOld.Genres = (List<Genre>)_generalService.GetGenresFromVM(filmViewModel.Genres);
            filmOld.Directors = (List<Artist>)_generalService.GetArtistsFromVM(filmViewModel.Directors);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<ShowFilmsViewModel>> ShowFilmViewmodelsAsync()
        {
            List<ShowFilmsViewModel> ShowFilmsViewModel = new();
            foreach (var film in _applicationDbContext.Medias.OfType<Film>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors))
            {
                ShowFilmsViewModel.Add(new ShowFilmsViewModel
                {
                    Id = film.Id,
                    Title = film.Title,
                    ReleaseDate = film.ReleaseDate,
                    Duration = film.Duration,
                    Url = film.Url,
                    Actors = film.Actors,
                    Reviews = film.Reviews,
                    Genres = film.Genres,
                    Directors = film.Directors
                }); 
            }
            return ShowFilmsViewModel;
        }

         public async Task<List<ShowFilmsViewModel>> ShowMyFilmViewmodelsAsync(string userId)
        {
            List<ShowFilmsViewModel> ShowFilmsViewModel = new();
            var ctx =  _applicationDbContext.Medias.OfType<Film>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors).Where(x => x.UserId.Equals(userId));

            foreach (var film in ctx)
            {
                ShowFilmsViewModel.Add(new ShowFilmsViewModel
                {
                    Id = film.Id,
                    Title = film.Title,
                    ReleaseDate = film.ReleaseDate,
                    Duration = film.Duration,
                    Url = film.Url,
                    Actors = film.Actors,
                    Reviews = film.Reviews,
                    Genres = film.Genres,
                    Directors = film.Directors
                }); 
            }
            return ShowFilmsViewModel;
        }

        public async Task DeleteFilmAsync(int id)
        {
            _applicationDbContext.Medias.Remove(
                _applicationDbContext.Medias
                .Include(film => film.Reviews)
                .Include(film => (film as Film).Actors)
                .Include(film => (film as Film).Directors)
                .FirstOrDefault(film => film.Id.Equals(id)));


            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<ShowFilmsViewModel> GetVMFromIDAsync(int id)
        {
            var filmFound = await _applicationDbContext.Medias.OfType<Film>().Include(x => x.Actors).Include(x => x.Genres).Include(x => x.Directors).FirstOrDefaultAsync(film => film.Id.Equals(id));
            var filmVM = new ShowFilmsViewModel()
            {
                Id = filmFound.Id,
                Duration = filmFound.Duration,
                Url = filmFound.Url,
                ReleaseDate = filmFound.ReleaseDate,
                Title = filmFound.Title,
                Reviews = filmFound.Reviews,
                Directors = filmFound.Directors,
                Actors = filmFound.Actors,
                Genres = filmFound.Genres
            };
            return filmVM;
        }
    }
}
