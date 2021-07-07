using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistTypes ArtistType { get; set; }

        public List<Media> Medias { get; set; }
    }
}
