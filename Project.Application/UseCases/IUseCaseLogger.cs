using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLogApp log);
    }

    public class UseCaseLogApp
    {
        public string UseCaseName { get; set; }
        public string User { get; set; }
        public int? UserID { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Data { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
