using Application;
using Application.Interfaces;
using DataAccess;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class UseCaseLoggerDatabase : IUseCaseLogger
    {
        private readonly Context _context;

        public UseCaseLoggerDatabase(Context context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationUser user, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                UserId = user.Id,
                UserUserName = user.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                Name = useCase.Name
            });

            _context.SaveChanges();
        }
    }
}
