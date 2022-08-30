using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domen
{
    public class Album : Entity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Published { get; set; }
        public int ArtistID { get; set; }

        public IEnumerable<AlbumGenre> Genres = new List<AlbumGenre>();
        public IEnumerable<Song> Songs = new List<Song>();
        public IEnumerable<Like> Likes = new List<Like>();
        public IEnumerable<OrderLine> OrderLines = new List<OrderLine>();
        public Artist Artist { get; set; }
    }
}
