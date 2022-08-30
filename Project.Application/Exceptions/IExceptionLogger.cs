using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Exceptions
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
