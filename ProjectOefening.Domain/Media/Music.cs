using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Music : Media
    {
        [ForeignKey("MusicArtistId")]
        public List<Artist> MusicArtists { get; set; }
    }   
}
