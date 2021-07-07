using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class ShowMediaViewModel : IViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        [Display(Name = "Releasedate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }
        public string Url { get; set; }


        public List<Review> Reviews { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
