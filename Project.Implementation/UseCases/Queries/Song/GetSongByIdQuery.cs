using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class GetSongByIdQuery : EfUseCase, IGetSongByIdQuery
    {
        public GetSongByIdQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Find song";

        public string Description => "";

        public SongDTO Execute(int request)
        {
            var song = context.Songs.Include(x => x.Artists).ThenInclude(x=>x.Artist)
                                    .Include(x => x.Album)
                                    .FirstOrDefault(x => x.IsActive && x.Id == request);

            if (song == null)
                throw new EntityNotFoundException(nameof(song), request);

            return new SongDTO
            {
                ID = song.Id,
                Name = song.Name,
                Duration = song.Duration,
                Artists = song.Artists.Select(x=>x.Artist.Fullname),
                Album = song.Album.Name
            };
        }
    }
}
