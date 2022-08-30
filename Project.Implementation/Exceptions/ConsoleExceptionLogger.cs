using Project.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.Exceptions
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Occured at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
        }
    }
}
