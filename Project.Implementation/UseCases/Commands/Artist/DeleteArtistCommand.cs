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
    public class DeleteArtistCommand : EfUseCase, IDeleteArtistCommand
    {
        public DeleteArtistCommand(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 17;
        public string Name => "Delete artist";
        public string Description => "";

        public void Execute(int request)
        {
            var artist = context.Artists.FirstOrDefault(x => x.IsActive && x.Id == request);

            if (artist == null)
                throw new EntityNotFoundException(nameof(Artist), request);

            if (artist.Songs.Any())
                throw new ConflictException("Artist can't be deleted because he has songs in system.");

            if(artist.Albums.Any())
                throw new ConflictException("Artist can't be deleted because he has albums in system.");

            context.SongArtists.RemoveRange(artist.Songs);
            context.Artists.Remove(artist);
            context.SaveChanges();
        }
    }
}
