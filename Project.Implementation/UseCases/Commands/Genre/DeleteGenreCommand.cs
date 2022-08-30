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
    public class DeleteGenreCommand : EfUseCase, IDeleteGenreCommand
    {
        public DeleteGenreCommand(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 4;
        public string Name => "Delete genre";
        public string Description => "";

        public void Execute(int request)
        {
            var genre = context.Genres.Include(x => x.Albums).FirstOrDefault(x => x.IsActive && x.Id == request);

            if(genre == null)
                throw new EntityNotFoundException(nameof(Genre), request);

            if (genre.Albums.Any())
                throw new ConflictException("Genre can't be deleted because it has albums.");

            context.AlbumGenres.RemoveRange(genre.Albums);
            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }
}
