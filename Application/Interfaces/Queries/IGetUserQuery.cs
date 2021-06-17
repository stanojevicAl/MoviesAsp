using Application.DataTransfer;
using Application.DataTransfer.Users;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IGetUserQuery : IQuery<CommonSearch, PagesResponse<ReadUserDto>>
    {
    }
}
