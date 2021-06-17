using Application.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class CommonSearch : PagesSearch
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
