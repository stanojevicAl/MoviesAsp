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
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ReadActorDto>()
                .ForMember(x => x.Movies, y => y.MapFrom(movie => movie.MovieActors.Select(m => 
                new MovieForActorgenreDto
                { 
                    Id = m.Movie.Id,
                    Name = m.Movie.Name
                })));
            CreateMap<ActorDto, Actor>();

        }
    }
}
