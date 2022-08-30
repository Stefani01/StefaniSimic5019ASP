using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class GenreDTO : BaseDTO
    {
        public int NumberOfAlbums { get; set; }
    }

    public class CreateGenreDTO
    {
        public string Name { get; set; }
    }

    public class UpdateGenreDTO : CreateGenreDTO
    {
        public int GenreID { get; set; }
    }
}
