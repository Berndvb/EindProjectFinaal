using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Score { get; set; }
        //public Users Owner { get; set; }

        public int MediaItemId { get; set; }
    }
}
