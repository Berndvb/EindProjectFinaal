using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class TVSerie : Media
    {
        public int Episodes { get; set; }
        public int Seasons { get; set; }

        [ForeignKey("ActorId")]
        public List<Artist> Actors { get; set; }

        [ForeignKey("DirectorId")]
        public List<Artist> Directors { get; set; }
    }
}
