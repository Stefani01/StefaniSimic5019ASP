using FluentValidation;
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
    public class UpdateSongCommand : EfUseCase, IUpdateSongCommand
    {
        private CreateSongValidator _validator;
        public UpdateSongCommand(ProjectDbContext context, CreateSongValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;
        public string Name => "Update song";

        public string Description => "";

        public void Execute(UpdateSongDTO request)
        {
            var song = context.Songs.Include(x => x.Artists).FirstOrDefault(x => x.IsActive && x.Id == request.SongID);
            if (song == null)
                throw new EntityNotFoundException(nameof(Song), request.SongID);

            _validator.ValidateAndThrow(request);

            context.SongArtists.RemoveRange(song.Artists);
            song.Name = request.Name;
            song.AlbumID = request.AlbumID;
            song.Duration = request.Duration;

            var songArtist = request.ArtistIDs.Select(x => new SongArtist
            {
                Song = song,
                ArtistID = x
            });

            context.SongArtists.AddRange(songArtist);
            context.SaveChanges();
        }
    }
}
