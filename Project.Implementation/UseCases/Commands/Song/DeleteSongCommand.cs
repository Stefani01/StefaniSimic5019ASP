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
    public class DeleteSongCommand : EfUseCase, IDeleteSongCommand
    {
        public DeleteSongCommand(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 18;
        public string Name => "Delete song";
        public string Description => "";

        public void Execute(int request)
        {
            var song = context.Songs.Include(x => x.Artists).FirstOrDefault(x => x.IsActive && x.Id == request);

            if (song == null)
                throw new EntityNotFoundException(nameof(Song), request);

            context.SongArtists.RemoveRange(song.Artists);
            context.Songs.Remove(song);
            context.SaveChanges();
        }
    }
}
