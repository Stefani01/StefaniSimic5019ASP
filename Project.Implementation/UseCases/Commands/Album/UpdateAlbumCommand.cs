using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.DataAccess;
using Project.Domen;
using Project.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Commands
{
    public class UpdateAlbumCommand : EfUseCase, IUpdateAlbumCommand
    {
        private CreateAlbumValidator _validator;
        public UpdateAlbumCommand(ProjectDbContext context, CreateAlbumValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 23;
        public string Name => "Update album";
        public string Description => "";

        public void Execute(UpdateAlbumDTO request)
        {
            var album = context.Albums.Include(x => x.Genres)
                                        .FirstOrDefault(x => x.IsActive && x.Id == request.AlbumID);

            if (album == null)
                throw new EntityNotFoundException(nameof(Album), request.AlbumID);

            _validator.Validate(request);
            context.AlbumGenres.RemoveRange(album.Genres);

            album.Price = request.Price;
            album.ImagePath = request.ImagePath;
            album.Name = request.Name;
            album.ArtistID = request.ArtistID;
            album.Published = DateTime.ParseExact(request.Published, "dd/MM/yyyy", null);

            var newGenres = request.GenreIDs.Select(x => new AlbumGenre
            {
                Album = album,
                GenreID = x
            }); 
            context.AlbumGenres.AddRange(newGenres);
            context.SaveChanges();
        }
    }
}
