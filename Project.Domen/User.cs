using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class User : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public IEnumerable<Like> Likes = new List<Like>();
        public IEnumerable<UseCase> UseCases { get; set; } = new List<UseCase>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
