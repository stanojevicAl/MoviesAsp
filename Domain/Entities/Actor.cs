using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Actor : Entity
    {
        public string LastName { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new HashSet<MovieActor>();
    }
}
