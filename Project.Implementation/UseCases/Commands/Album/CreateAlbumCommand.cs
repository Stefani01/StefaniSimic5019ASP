using FluentValidation;
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
    public class CreateAlbumCommand : EfUseCase, ICreateAlbumCommand
    {
        private CreateAlbumValidator _validator;
        public CreateAlbumCommand(ProjectDbContext context, CreateAlbumValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 21;
        public string Name => "Add new album";
        public string Description => "";

        public void Execute(CreateAlbumDTO request)
        {
            _validator.ValidateAndThrow(request);

            var albumArtist = context.Albums.FirstOrDefault(x => x.Name == request.Name && x.ArtistID == request.ArtistID);

            if (albumArtist != null)
                throw new ConflictException($"Album {request.Name} of artist with ID: {request.ArtistID} already exist in system.");

            var newAlbum = new Album
            {
                ArtistID = request.ArtistID,
                ImagePath = request.ImagePath,
                Name = request.Name,
                Published = DateTime.ParseExact(request.Published, "dd/MM/yyyy", null),
                Price = request.Price
            };

            var albumGenres = request.GenreIDs.Select(x => new AlbumGenre
            {
                Album = newAlbum,
                GenreID = x
            });

            context.Albums.Add(newAlbum);
            context.AlbumGenres.AddRange(albumGenres);
            context.SaveChanges();
        }
    }
}
