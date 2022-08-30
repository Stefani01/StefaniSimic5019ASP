using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class Song : Entity
    {
        public int AlbumID {get;set;}
        public string Name { get; set; }
        public string Duration { get; set; }

        public Album Album { get; set; }
        public IEnumerable<SongArtist> Artists = new List<SongArtist>();
    }
}
