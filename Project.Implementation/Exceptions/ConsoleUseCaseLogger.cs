using Project.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.Exceptions
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(UseCaseLogApp log)
        {
            Console.WriteLine($"UseCase: {log.UseCaseName}, User: {log.User}, ID: {log.UserID}, {log.ExecutionTime}, Authorized: {log.IsAuthorized}");
            Console.WriteLine($"Use Case data: {log.Data}");
        }
    }
}
