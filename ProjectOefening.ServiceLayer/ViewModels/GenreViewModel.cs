using ProjectOefening.Domain;
using ProjectOefening.Domain.Genres;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class GenreViewModel : IViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public GenreTypes Genretype { get; set; }

        [Required]
        public List<Media> Media { get; set; }
    }
}
