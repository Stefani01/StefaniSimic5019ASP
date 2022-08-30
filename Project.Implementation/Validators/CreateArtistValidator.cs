using FluentValidation;
using Project.Application.UseCases.DTO;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.Validators
{
    public class CreateArtistValidator : AbstractValidator<CreateArtistDTO>
    {
        public CreateArtistValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of artist is required")
                              .MinimumLength(2).WithMessage("Name of artist can't have less then 2 characters.")
                              .MaximumLength(70).WithMessage("Name of artist can't have less then 2 characters.")
                              .Must(x => !context.Artists.Any(a => a.Fullname == x)).WithMessage("Artist with name: '{PropertyValue}' already exist.");
        }
    }
}
