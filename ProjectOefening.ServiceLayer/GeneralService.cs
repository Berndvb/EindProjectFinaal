using Microsoft.EntityFrameworkCore;
using ProjectOefening.Domain;
using ProjectOefening.Domain.Genres;
using ProjectOefening.Repository;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer
{
    public class GeneralService : IGeneralService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GeneralService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }


        public void CreateGenre(GenreViewModel genreViewModel)
        {
            var genre = new Genre() { Name = genreViewModel.Name, Genretype = genreViewModel.Genretype };
            _applicationDbContext.Genres.Add(genre);
            _applicationDbContext.SaveChanges();
        }

        public void CreateArtist(ArtistViewModel artistViewModel)
        {
            var artist = new Artist() { Name = artistViewModel.Name, ArtistType = artistViewModel.ArtistType };
            _applicationDbContext.Artists.Add(artist);
            _applicationDbContext.SaveChanges();
        }

        public List<ArtistViewModel> ShowAllArtists()
        {
            List<ArtistViewModel> artistViewModels = new();
            var allArtists = _applicationDbContext.Artists.Include(x => x.Medias);
            foreach (var artist in allArtists)
            {
                artistViewModels.Add(new ArtistViewModel { Name = artist.Name, Id = artist.Id, ArtistType = artist.ArtistType, Media = artist.Medias });
            }
            var artistsOrdered = artistViewModels.OrderBy(artist => artist.ArtistType).ToList();
            return artistsOrdered;
        }

        public List<GenreViewModel> ShowAllGenres()
        {
            List<GenreViewModel> genreViewModels = new();
            var allGenres = _applicationDbContext.Genres.Include(x => x.Media);
            foreach (var genre in allGenres)
            {
                genreViewModels.Add(new GenreViewModel { Name = genre.Name, Id = genre.Id, Genretype = genre.Genretype, Media = genre.Media});
            }
            var genresOrdered = genreViewModels.OrderBy(genre => genre.Genretype).ToList();
            return genresOrdered;
        }

        public IEnumerable GetArtistsFromVM(List<int> Ids)
        {
            List<Artist> artists = new();

            if (Ids != null)
            {
                foreach (var artistId in Ids) 
                {
                    artists.Add(_applicationDbContext.Artists
                       .FirstOrDefault(x => x.Id.Equals(artistId)));
                }
            }
            return artists;
        }

        public IEnumerable GetGenresFromVM(List<int> Ids)
        {
            List<Genre> genres = new();
            if (Ids != null)
            {
                foreach (var genreId in Ids)
                {
                    genres.Add(_applicationDbContext.Genres
                       .FirstOrDefault(x => x.Id.Equals(genreId)));
                }
            }
            return genres;
        }

        public void DeleteArtist(int id)
        {
            _applicationDbContext.Artists.Remove(
                _applicationDbContext.Artists.FirstOrDefault(artist => artist.Id.Equals(id)));
            _applicationDbContext.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            _applicationDbContext.Genres.Remove(
                _applicationDbContext.Genres.FirstOrDefault(genre => genre.Id.Equals(id)));
            _applicationDbContext.SaveChanges();
        }

        public void Edit(IViewModel vm) 
        {
            
            switch (vm)
            {
                case ArtistViewModel:
                    var vm1 = _applicationDbContext.Artists.FirstOrDefault(x => x.Id.Equals((vm as ArtistViewModel).Id));
                    vm1.Name = (vm as ArtistViewModel).Name;
                    vm1.ArtistType = (vm as ArtistViewModel).ArtistType;
                    break;
                case GenreViewModel:
                    var vm2 = _applicationDbContext.Genres.FirstOrDefault(x => x.Id.Equals((vm as GenreViewModel).Id));
                    vm2.Name = (vm as GenreViewModel).Name;
                    vm2.Genretype = (vm as GenreViewModel).Genretype;
                    break;
                default:
                    break;
            }
            _applicationDbContext.SaveChanges();
        }

        public ArtistViewModel GetArtistVMFromID(int id)//search & mapper opsplitsen
        {
            var artistFound = _applicationDbContext.Artists.FirstOrDefault(artist => artist.Id.Equals(id));
            var artistVM = new ArtistViewModel()
            {
                Id = artistFound.Id,
                Name = artistFound.Name,
                ArtistType = artistFound.ArtistType
            };
            return artistVM;
        }

        public GenreViewModel GetGenreVMFromID(int id)
        {
            var genreFound = _applicationDbContext.Genres.FirstOrDefault(genre => genre.Id.Equals(id));
            var genreVM = new GenreViewModel()
            {
                Id = genreFound.Id,
                Name = genreFound.Name,
                Genretype = genreFound.Genretype
            };
            return genreVM;
        }

        public Media GetMediaItemFromID(int id)
        {
            return _applicationDbContext.Medias.FirstOrDefault(media => media.Id.Equals(id));
        }

        public IEnumerable<Media> GetMedia()
        {
            return _applicationDbContext.Medias.Include(x => x.Reviews).ToList();
        }

        public string GetMediaType(int id)
        {
            var mediaObject = _applicationDbContext.Medias.FirstOrDefault(x => x.Id.Equals(id));
            return mediaObject.GetType().Name;
        }
    }
}
