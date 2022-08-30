using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class GetArtistByIdQuery : EfUseCase, IGetArtistByIdQuery
    {
        public GetArtistByIdQuery(ProjectDbContext context) : base(context)
        {
        }
        public int Id => 8;
        public string Name => "Find artist";
        public string Description => "";

        public ArtistDTO Execute(int request)
        {
            var artist = context.Artists.Include(x=>x.Albums).ThenInclude(x=>x.Songs)
                                        .Where(x => x.IsActive && x.Id == request).FirstOrDefault();

            if (artist == null)
                throw new EntityNotFoundException(nameof(Artist), request);

            return new ArtistDTO
            {
                ID = request,
                Name = artist.Fullname,
                Work = artist.Albums.Select(x=> new ArtistAlbumSongsDTO
                {
                    Album = x.Name,
                    Songs = x.Songs.Select(x=> new ArtistSongDTO
                    {
                        Name = x.Name
                    })
                })
            };
        }
    }
}
