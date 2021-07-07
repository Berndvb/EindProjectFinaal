using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.ServiceLayer.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public string ReviewText { get; set; }

        [Required]
        [Range(0,10)]
        [Display(Name = "Score (out of 10)")]
        public int Score { get; set; }

        //[Required]
        //public Users Owner { get; set; }

        [Required]
        public int MediaItemId { get; set; }
    }
}
