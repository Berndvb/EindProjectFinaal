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
    public class PlaylistService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PlaylistService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public void CreateReview(PlaylistViewModel playlistVM)
        {
            var playlist = new Playlist()
            {
                //Owner = playlistVM.Owner,
                Name = playlistVM.Name,
                Medias = playlistVM.Medias
            };

            _applicationDbContext.Playlists.Add(playlist);
            _applicationDbContext.SaveChanges();
        }
        public void EditReview(PlaylistViewModel playlistVM)
        {
            var foundPlaylist = _applicationDbContext.Playlists.Include(x => x.Medias).FirstOrDefault(x => x.Id.Equals(playlistVM.Id));

            //foundPlaylist.Owner = playlistVM.Owner;
            foundPlaylist.Name = playlistVM.Name;
            foundPlaylist.Medias = playlistVM.Medias;

            _applicationDbContext.SaveChanges();
        }
        public void DeleteReview(int id)
        {
            _applicationDbContext.Playlists.Remove(
              _applicationDbContext.Playlists.FirstOrDefault(playlist => playlist.Id.Equals(id)));
            _applicationDbContext.SaveChanges();
        }
    }
}
