using Application.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class MovieSearch : CommonSearch
    {
        public double? MinRating { get; set; }
        public double? MaxRating { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public int? MaxDuration { get; set; }
    }
}
