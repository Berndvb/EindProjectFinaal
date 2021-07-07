using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Film : Media
    {
        [ForeignKey("DirectorId")]
        public List<Artist> Directors { get; set; }

        [ForeignKey("ActorId")]
        public List<Artist> Actors { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

    }
}
