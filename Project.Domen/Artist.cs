using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class Artist : Entity
    {
        public string Fullname { get; set; }

        public IEnumerable<SongArtist> Songs = new List<SongArtist>();
        public IEnumerable<Album> Albums = new List<Album>();
    }
}
