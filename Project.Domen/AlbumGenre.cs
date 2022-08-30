using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class AlbumGenre
    {
        public int GenreID { get; set; }
        public int AlbumID { get; set; }

        public Genre Genre { get; set; }
        public Album Album { get; set; }
    }
}
