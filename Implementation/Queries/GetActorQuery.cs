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
    public class GetActorQuery : IGetActorQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetActorQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get actors";

        public PagesResponse<ReadActorDto> Execute(CommonSearch search)
        {
            var query = _context.Actors
                .Include(x => x.MovieActors)
                .ThenInclude(y => y.Movie)
                .Where(x => x.Active == true && x.DeleteAt == null)
                .AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                if (query == null){
                    throw new EntityNotFoundException(typeof(Actor));
                }
            }

            if (!string.IsNullOrEmpty(search.Name))
            {
                var name = search.Name.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(name) || x.LastName.ToLower().Contains(name));
            }

            var actors = query.Paged<ReadActorDto, Actor>(search, _mapper);
            if (actors.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Actor));
            }
            return actors;
        }
    }
}
