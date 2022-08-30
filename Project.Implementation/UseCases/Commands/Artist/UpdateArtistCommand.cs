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
    public class UpdateArtistCommand : EfUseCase, IUpdateArtistCommand
    {
        private CreateArtistValidator _validator;
        public UpdateArtistCommand(ProjectDbContext context, CreateArtistValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 10;
        public string Name => "Update artist";
        public string Description => "";

        public void Execute(UpdateArtistDTO request)
        {
            if (request.ArtistID <= 0)
                throw new ConflictException("Artist ID must be greater than 0.");

            var artist = context.Artists.FirstOrDefault(x => x.IsActive && x.Id == request.ArtistID);
            if (artist == null)
                throw new EntityNotFoundException(nameof(Artist), request.ArtistID);

            _validator.ValidateAndThrow(request);

            artist.Fullname = request.Name;
            context.SaveChanges();
        }
    }
}
