using Application;
using Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class UseCaseLoggerConsole : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationUser user, object useCaseData)
        {
            Console.WriteLine($"{DateTime.Now}: {user.Identity} is trying to execute {useCase.Name} using data: " +
                $"{JsonConvert.SerializeObject(useCaseData)}");
        }
    }
}
