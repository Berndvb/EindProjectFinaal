using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class ShowTVSerieViewModel : ShowMediaViewModel
    {
        public int Episodes { get; set; }
        public int Seasons { get; set; }

        public List<Artist> Actors { get; set; }
        public List<Artist> Directors { get; set; }
    }
}
