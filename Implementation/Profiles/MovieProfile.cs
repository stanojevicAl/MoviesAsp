using Application.DataTransfer;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, ReadMovieDto>()
                .ForMember(x => x.Actors, y => y.MapFrom(actor => actor.MovieActors.Select(a => 
                new ActorDto
                {
                    Id = a.Actor.Id,
                    Name = a.Actor.Name,
                    LastName = a.Actor.LastName
                })))
                .ForMember(x => x.Genres, y => y.MapFrom(genre => genre.MovieGenres.Select(g =>
                new GenreDto
                {
                    Id = g.Genre.Id,
                    Name = g.Genre.Name
                })))
                .ForMember(x => x.Comments, y => y.MapFrom(com => com.MovieComments.Select(c =>
                new MovieCommentDto
                {
                    UserName = c.User.Username,
                    Comment = c.Comment,
                    Date = c.CommentDate
                })))
                .ForMember(x => x.Rating, y => y.MapFrom(rating => rating.MovieRatings.Any(r => r.Movie == rating) ? rating.MovieRatings.Average(r =>r.Rating).ToString() : "Movie has not been rated yet"));
        }
    }
}
