using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetLoggetQuery : IGetLoggerQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetLoggetQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 19;

        public string Name => "Get logger";

        public PagesResponse<LoggerDto> Execute(LoggerSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            if (!string.IsNullOrEmpty(search.UserUserName) && !string.IsNullOrWhiteSpace(search.UserUserName))
            {
                search.UserUserName = search.UserUserName.ToLower();

                query = query.Where(x => x.UserUserName.ToLower().Contains(search.UserUserName));
            }

            if (search.DateFrom.HasValue && search.DateTo.HasValue)
            {
                query = query.Where(x => x.Date >= search.DateFrom && x.Date <= search.DateTo);
            }

            var logs = query.Paged<LoggerDto, UseCaseLog>(search, _mapper);

            if (logs.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(UseCaseLog));
            }
            return logs;
        }
    }
}
