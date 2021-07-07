using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class ShowFilmsViewModel : ShowMediaViewModel
    {
        public List<Artist> Directors { get; set; }
        public List<Artist> Actors { get; set; }
        public string UserId { get; set; }
    }
}
