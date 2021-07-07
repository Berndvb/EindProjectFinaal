using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Media> Medias { get; set; }
    }
}
