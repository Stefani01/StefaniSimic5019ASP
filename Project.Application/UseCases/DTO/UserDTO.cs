using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserFrom { get; set; }
        public IEnumerable<int> UseCaseIDs { get; set; }
        public int Orders {get;set;}
        public int AlbumLikes { get; set; }
    }

}
