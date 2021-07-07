using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class TVSerieViewModel : MediaViewModel
    {
        [Required]
        [Range(1, 50)]
        public int Episodes { get; set; }

        [Required]
        [Range(1,30)]
        public int Seasons { get; set; }

        [Required]
        public List<int> Actors { get; set; }

        [Required]
        public List<int> Directors { get; set; }
    }
}
