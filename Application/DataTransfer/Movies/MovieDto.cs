using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string Link { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile CoverImage { get; set; }
        public ICollection<MovieGereDto> Genres { get; set; } = new List<MovieGereDto>();
        public ICollection<MovieActorDto> Actors { get; set; } = new List<MovieActorDto>();
    }

    public class MovieActorDto
    {
        public int ActorId { get; set; }
    }

    public class MovieGereDto
    {
        public int GenreId { get; set; }
    }

}
