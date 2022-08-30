using Project.Domen;
using System.Collections.Generic;

namespace Project.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }
        public int ID { get; set; }
        public IEnumerable<int> UseCaseIDs { get; set; } = new List<int>();
        public string Email { get; set; }
    }

    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Anonymous";
        public int ID => 0;
        public IEnumerable<int> UseCaseIDs => new List<int> { 1, 2, 3, 7, 8, 12, 13, 14, 15 };
        public string Email => "anonimous@album.com";
    }
}
