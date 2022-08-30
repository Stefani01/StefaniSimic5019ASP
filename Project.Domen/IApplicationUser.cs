using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public interface IApplicationUser
    {
        public string Identity { get; } // username
        public int ID { get; }
        public IEnumerable<int> UseCaseIDs { get; }
        public string Email { get; }
    }
}
