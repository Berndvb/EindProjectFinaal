using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Podcast : Media
    {
        [ForeignKey("HostId")]
        public List<Artist> Hosts { get; set; }

        [ForeignKey("GuestId")]
        public List<Artist> Guests { get; set; }
    }
}
