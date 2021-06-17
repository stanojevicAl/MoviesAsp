using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class ReadActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<MovieForActorgenreDto> Movies { get; set; } = new List<MovieForActorgenreDto>();
    }

    public class MovieForActorgenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
