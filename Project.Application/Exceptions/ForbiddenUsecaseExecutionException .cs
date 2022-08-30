using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Exceptions
{
    public class ForbiddenUsecaseExecutionException : Exception
    {
        public ForbiddenUsecaseExecutionException(string useCase, string user)
           : base($"User {user} has tried to execute {useCase} without being authorized.")
        {
        }
    }
}
