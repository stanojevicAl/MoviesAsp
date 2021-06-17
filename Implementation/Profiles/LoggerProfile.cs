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
    public class LoggerProfile : Profile
    {
        public LoggerProfile()
        {
            CreateMap<UseCaseLog, LoggerDto>();
        }
    }
}
