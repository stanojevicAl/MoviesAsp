using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : Entity
    {
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new HashSet<MovieActor>();
        public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new HashSet<UserFavorite>();
        public virtual ICollection<MovieComment> MovieComments { get; set; } = new HashSet<MovieComment>();
        public virtual ICollection<MovieRating> MovieRatings { get; set; } = new HashSet<MovieRating>();
    }
}
