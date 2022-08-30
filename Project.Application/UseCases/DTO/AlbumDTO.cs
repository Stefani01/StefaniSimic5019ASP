using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class AlbumDTO : BaseDTO
    {
        public string Price { get; set; }
        public string Image { get; set; }
        public string Published { get; set; }
        public string Artist { get; set; }
        public int Likes { get; set; }
        public IEnumerable<AlbumSongsDTO> Songs { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }

    public class AlbumSongsDTO : BaseDTO { }

    public class CreateAlbumDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Published { get; set; }
        public int ArtistID { get; set; }
        public IEnumerable<int> GenreIDs { get; set; }
    }

    public class UpdateAlbumDTO : CreateAlbumDTO
    {
        public int AlbumID { get; set; }
    }
  
   
}
