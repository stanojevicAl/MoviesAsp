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
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<UserFavorite, ReadFavoriteMovieDto>()
                .ForMember(x => x.IdMovie, y => y.MapFrom(movie => movie.Movie.Id))
                .ForMember(x => x.Name, y => y.MapFrom(movie => movie.Movie.Name))
                .ForMember(x => x.Image, y => y.MapFrom(movie => movie.Movie.Image))
                .ForMember(x => x.Year, y => y.MapFrom(movie => movie.Movie.Year));
        }
    }
}
