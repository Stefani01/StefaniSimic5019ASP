using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation
{
    public abstract class EfUseCase
    {
        protected ProjectDbContext context;
        protected EfUseCase(ProjectDbContext context)
        {
            this.context = context;
        }
    }
}
