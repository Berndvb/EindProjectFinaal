using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class PlaylistViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        //public Users Owner { get; set; }

        [Required] 
        public List<Media> Medias { get; set; }
    }
}
