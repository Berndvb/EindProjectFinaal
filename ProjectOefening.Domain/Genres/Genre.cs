using ProjectOefening.Domain.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreTypes Genretype { get; set; }
        public List<Media> Media { get; set; }
    }
}
