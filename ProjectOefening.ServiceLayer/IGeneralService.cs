using ProjectOefening.Domain;
using ProjectOefening.ServiceLayer.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer
{
    public interface IGeneralService
    {
         void CreateGenre(GenreViewModel genreViewModel);
         void CreateArtist(ArtistViewModel artistViewModel);
         List<ArtistViewModel> ShowAllArtists();
         List<GenreViewModel> ShowAllGenres();
         IEnumerable GetArtistsFromVM(List<int> Ids);
         IEnumerable GetGenresFromVM(List<int> Ids);
         void DeleteArtist(int id);
         void DeleteGenre(int id);
         void Edit(IViewModel vm);
         ArtistViewModel GetArtistVMFromID(int id);
         GenreViewModel GetGenreVMFromID(int id);
         Media GetMediaItemFromID(int id);
         IEnumerable<Media> GetMedia();
         string GetMediaType(int id);
    }
}

