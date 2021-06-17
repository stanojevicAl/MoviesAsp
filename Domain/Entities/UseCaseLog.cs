using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UseCaseLog : Entity
    {
        public DateTime Date { get; set; }
        public string Data { get; set; }
        public string UserUserName { get; set; }
        public int UserId { get; set; }

    }
}
