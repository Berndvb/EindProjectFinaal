using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class ShowMusicViewModel : ShowMediaViewModel
    {
        public List<Artist> MusicArtists { get; set; }
    }
}
