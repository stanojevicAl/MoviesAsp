using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class ReadMovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string link { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public string? Rating { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public IEnumerable<ActorDto> Actors { get; set; } = new List<ActorDto>();
        public IEnumerable<MovieCommentDto> Comments { get; set; } = new List<MovieCommentDto>();
    }

    public class MovieCommentDto
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
