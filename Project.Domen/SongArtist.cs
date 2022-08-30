using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class SongArtist
    {
        public int SongID { get; set; }
        public int ArtistID { get; set; }

        public Song Song { get; set; }
        public Artist Artist { get; set; }
    }
}
