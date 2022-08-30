using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        public IEnumerable<AlbumGenre> Albums { get; set; } = new List<AlbumGenre>();
    }
}
