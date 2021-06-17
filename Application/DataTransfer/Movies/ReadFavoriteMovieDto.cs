using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class ReadFavoriteMovieDto
    {
        public int IdMovie { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
    }
}
