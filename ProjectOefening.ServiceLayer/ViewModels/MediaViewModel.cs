using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class MediaViewModel : IViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Releasedate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,300)]
        public int Duration { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Url { get; set; }

        public List<Review> Reviews { get; set; }

        [Required]
        public List<int> Genres { get; set; }
    }
}
