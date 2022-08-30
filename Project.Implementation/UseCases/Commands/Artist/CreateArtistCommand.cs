using FluentValidation;
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
    public class CreateArtistCommand : EfUseCase, ICreateArtistCommand
    {
        private CreateArtistValidator _validator;
        public CreateArtistCommand(ProjectDbContext context, CreateArtistValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;
        public string Name => "Add new artist";
        public string Description => "";

        public void Execute(CreateArtistDTO request)
        {
            _validator.ValidateAndThrow(request);

            var newArtist = new Artist
            {
                Fullname = request.Name
            };

            context.Artists.Add(newArtist);
            context.SaveChanges();
        }
    }
}
