using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class ArtistDTO : BaseDTO
    {
        public IEnumerable<ArtistAlbumSongsDTO> Work { get; set; }
    }

    public class ArtistAlbumSongsDTO
    {
       public string Album { get; set; }
       public IEnumerable <ArtistSongDTO> Songs { get; set; }
    }

    public class ArtistSongDTO
    {
        public string Name { get; set; }
    }

    public class CreateArtistDTO
    {
        public string Name { get; set; }
    }

    public class UpdateArtistDTO : CreateArtistDTO
    {
        public int ArtistID { get; set; }
    }
}
