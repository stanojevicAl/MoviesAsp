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
    public class GetGenreQuery : IGetGenreQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetGenreQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Get genres";

        public PagesResponse<ReadGenreDto> Execute(CommonSearch search)
        {
            var query = _context.Genres
                        .Include(x => x.MovieGenres)
                        .ThenInclude(x => x.Movie)
                        .Where(x => x.DeleteAt == null)
                        .AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                if (query == null)
                {
                    throw new EntityNotFoundException(typeof(Genre));
                }
            }

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var genres = query.Paged<ReadGenreDto, Genre>(search, _mapper);

            if (genres.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Genre));
            }

            return genres;
        }
    }
}
