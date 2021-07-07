using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Url { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
