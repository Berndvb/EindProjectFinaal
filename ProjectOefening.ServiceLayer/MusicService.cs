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
    public class MusicService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IGeneralService _generalService;
        public MusicService(ApplicationDbContext applicationDbContext, IGeneralService generalService)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _generalService = generalService ?? throw new ArgumentNullException(nameof(generalService));
        }

        public void CreateMusic(MusicViewModel musicViewModel)
        {
            var music = new Music()
            {
                Title = musicViewModel.Title,
                ReleaseDate = musicViewModel.ReleaseDate,
                Duration = musicViewModel.Duration,
                Url = musicViewModel.Url,
                MusicArtists = (List<Artist>)_generalService.GetArtistsFromVM(musicViewModel.MusicArtists),
                Genres = (List<Genre>)_generalService.GetGenresFromVM(musicViewModel.Genres)
            };

            _applicationDbContext.Medias.Add(music);
            //LinkWithGenresArtists(musicViewModel, music);
            _applicationDbContext.SaveChanges();
        }
        public void DeleteMusic(int id)
        {
            _applicationDbContext.Medias.Remove(
                _applicationDbContext.Medias.Include(music => music.Reviews)
                .Include(music => (music as Music).MusicArtists)
                .FirstOrDefault(music => music.Id.Equals(id)));

            _applicationDbContext.SaveChanges();
        }

        public void EditMusic(MusicViewModel musicViewModel) // ref type
        {
            var musicOld = _applicationDbContext.Medias
                .OfType<Music>().Include(x => x.MusicArtists).Include(x => x.Genres)
                .FirstOrDefault(x => x.Id.Equals(musicViewModel.Id));

            //DeleteExistingLinks(filmOld as Film); // ??? - filmOld zogezegd geen artists

            musicOld.Title = musicViewModel.Title;
            musicOld.ReleaseDate = musicViewModel.ReleaseDate;
            musicOld.Duration = musicViewModel.Duration;
            musicOld.Url = musicViewModel.Url;
            musicOld.MusicArtists = (List<Artist>)_generalService.GetArtistsFromVM(musicViewModel.MusicArtists);
            musicOld.Genres = (List<Genre>)_generalService.GetGenresFromVM(musicViewModel.Genres);

            //LinkWithGenresArtists(filmViewModel, (filmOld as Film)); // ????
            _applicationDbContext.SaveChanges();
        }
        public ShowMusicViewModel GetVMFromID(int id)
        {
            var musicFound = _applicationDbContext.Medias.OfType<Music>().Include(x => x.MusicArtists).Include(x => x.Genres).FirstOrDefault(music => music.Id.Equals(id));
            var musicVM = new ShowMusicViewModel()
            {
                Id = musicFound.Id,
                Duration = musicFound.Duration,
                Url = musicFound.Url,
                ReleaseDate = musicFound.ReleaseDate,
                Title = musicFound.Title,
                Reviews = musicFound.Reviews,
                MusicArtists = musicFound.MusicArtists,
                Genres = musicFound.Genres
            };
            return musicVM;
        }

        public List<ShowMusicViewModel> ShowMusicViewmodels()
        {
            List<ShowMusicViewModel> musicViewmodels = new();

            foreach (var music in _applicationDbContext.Medias.OfType<Music>().Include(x => x.MusicArtists).Include(x => x.Genres))
            {
                musicViewmodels.Add(new ShowMusicViewModel
                {
                    Id = music.Id,
                    Title = music.Title,
                    ReleaseDate = music.ReleaseDate,
                    Duration = music.Duration,
                    Url = music.Url,
                    MusicArtists = music.MusicArtists,
                    Reviews = music.Reviews,
                    Genres = music.Genres,
                });
            }
            return musicViewmodels;
        }
    }
}
