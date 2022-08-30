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
    public class CreateSongCommand : EfUseCase, ICreateSongCommand
    {
        private CreateSongValidator _validator;
        public CreateSongCommand(ProjectDbContext context, CreateSongValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;
        public string Name => "Add new song";
        public string Description => "";

        public void Execute(CreateSongDTO request)
        {
            var songAlbum = context.Songs.FirstOrDefault(x => x.Name == request.Name && x.AlbumID == request.AlbumID);

            if (songAlbum != null)
                throw new ConflictException($"Song {request.Name} already exist in album.");

            _validator.ValidateAndThrow(request);

            var newSong = new Song
            {
                Name = request.Name,
                AlbumID = request.AlbumID,
                Duration = request.Duration,
            };

            var songArtist = request.ArtistIDs.Select(x => new SongArtist
            {
                Song = newSong,
                ArtistID = x
            });

            context.Songs.Add(newSong);
            context.SongArtists.AddRange(songArtist);
            context.SaveChanges();
        }
    }
}
