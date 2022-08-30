using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class UseCaseDTO
    {
        public int UserID { get; set; }
        public IEnumerable<int> UseCaseIDs { get; set; }
    }
}
