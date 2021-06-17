using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovieRating
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
