using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class PodcastViewModel : MediaViewModel
    {

        [Required]
        public List<int> Hosts { get; set; }


        [Required]
        public List<int> Guests { get; set; }
    }
}
