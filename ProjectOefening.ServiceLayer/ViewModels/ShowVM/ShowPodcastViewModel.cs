using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class ShowPodcastViewModel : ShowMediaViewModel
    {
        public List<Artist> Hosts { get; set; }
        public List<Artist> Guests { get; set; }
    }
}
