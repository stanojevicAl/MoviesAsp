using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Verification { get; set; }
        public string ActivationCode { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new HashSet<UserFavorite>();
        public virtual ICollection<MovieComment> MovieComments { get; set; } = new HashSet<MovieComment>();
        public virtual ICollection<MovieRating> MovieRatings { get; set; } = new HashSet<MovieRating>();
    }
}
