using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetMoviesQuery : IGetMoviesQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetMoviesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Search movies";

        public PagesResponse<ReadMovieDto> Execute(MovieSearch search)
        {
            var query = _context.Movies.Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.MovieActors)
                .ThenInclude(x => x.Actor)
                .Include(x => x.MovieRatings)
                .Include(x => x.MovieComments)
                .ThenInclude(x => x.User)
                .Where(x => x.Active == true && x.DeleteAt == null)
                .AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                if (query == null)
                {
                    throw new EntityNotFoundException(typeof(Movie));
                }
            }

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                var name = search.Name.ToLower();
                query = query.Where(x =>
                                    x.Name.ToLower().Contains(name) ||
                                    x.Description.ToLower().Contains(name) ||
                                    x.MovieActors.Any(a => a.Actor.Name.ToLower().Contains(name)) ||
                                    x.MovieGenres.Any(g => g.Genre.Name.ToLower().Contains(name)));
            }

            if (search.MinYear.HasValue)
            {
                query = query.Where(x => x.Year >= search.MinYear);
            }

            if (search.MaxYear.HasValue)
            {
                query = query.Where(x => x.Year <= search.MaxYear);
            }

            if (search.MaxDuration.HasValue)
            {
                query = query.Where(x => x.Duration <= search.MaxDuration);
            }

            if (search.MinRating.HasValue)
            {
                query = query.Where(x => x.MovieRatings.Average(y => y.Rating) >= search.MinRating);
            }

            if (search.MaxRating.HasValue)
            {
                query = query.Where(x => x.MovieRatings.Average(y => y.Rating) <= search.MaxRating);
            }

            var movies = query.Paged<ReadMovieDto, Movie>(search, _mapper);
            if(movies.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Movie));
            }

            return movies;
        }
    }
}
