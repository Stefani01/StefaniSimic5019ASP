using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class GetAlbumByIdQuery : EfUseCase, IGetAlbumByIdQuery
    {
        public GetAlbumByIdQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 13;
        public string Name => "Find album";
        public string Description => throw new NotImplementedException();

        public AlbumDTO Execute(int request)
        {
            var album = context.Albums.Include(x=>x.Genres).ThenInclude(x=>x.Genre)
                                        .Include(x=>x.Artist).Include(x=>x.Songs)
                                        .Where(x=>x.IsActive && x.Id == request).FirstOrDefault();
            if (album == null)
                throw new EntityNotFoundException(nameof(Album), request);

            return new AlbumDTO
            {
                ID = album.Id,
                Name = album.Name,
                Price = album.Price.ToString("C", CultureInfo.CurrentCulture),
                Published = album.Published.ToString("MMMM dd, yyyy"),
                Image = (album.ImagePath != null) ? album.ImagePath : "/",
                Likes = album.Likes.Count(),
                Songs = album.Songs.Select(x => new AlbumSongsDTO
                {
                    ID = x.Id,
                    Name = x.Name
                }).ToList(),
                Artist = album.Artist.Fullname,
                Genres = album.Genres.Select(g=>g.Genre.Name)
            };
        }
    }
}
