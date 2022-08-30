using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class UseCaseLog
    {
        public int Id { get; set; }
        public string UseCaseName { get; set; }
        public int? UserID { get; set; }
        public string Username { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Data { get; set; }
        public bool IsAuthorized { get; set; }

        public User User { get; set; }
    }
}
