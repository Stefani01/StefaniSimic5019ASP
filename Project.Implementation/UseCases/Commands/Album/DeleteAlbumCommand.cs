using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.Commands;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Commands
{
    public class DeleteAlbumCommand : EfUseCase, IDeleteAlbumCommand
    {
        public DeleteAlbumCommand(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 20;
        public string Name => "Delete album";
        public string Description => "";

        public void Execute(int request)
        {
            var album = context.Albums.Include(x => x.Genres)
                                        .Include(x => x.Songs).FirstOrDefault(x => x.IsActive && x.Id == request);

            if (album == null)
                throw new EntityNotFoundException(nameof(Album), request);

            if (album.Songs.Any())
                throw new ConflictException("Album can't be deleted beacuse it has songs.");

            context.AlbumGenres.RemoveRange(album.Genres);
            context.Albums.Remove(album);
            context.SaveChanges();
        }
    }
}
