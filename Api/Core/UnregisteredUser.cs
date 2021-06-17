using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class UnregisteredUser : IApplicationUser
    {
        public int Id => 0;

        public string Identity => "Unregistered user";

        public IEnumerable<int> AllowedUseCases => new List<int>{12,15,16,17,24};
    }
}
