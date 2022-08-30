using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class SongDTO : BaseDTO
    {
        public string Album { get; set; }
        public IEnumerable<string> Artists { get; set; }
        public string Duration { get; set; }
    }

    public class CreateSongDTO
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public int AlbumID { get; set; }
        public IEnumerable<int> ArtistIDs { get; set; }
    }

    public class UpdateSongDTO : CreateSongDTO
    {
        public int SongID { get; set; }
    }
}
