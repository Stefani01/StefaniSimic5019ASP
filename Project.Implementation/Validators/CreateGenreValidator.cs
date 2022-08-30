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
    public class CreateGenreValidator : AbstractValidator<CreateGenreDTO>
    {  
        public CreateGenreValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Genre name is required.")
                                .MaximumLength(50).WithMessage("Genre name can'thave more than 30 characters.")
                                .Must(x => !context.Genres.Any(g => g.Name == x)).WithMessage("Genre with name: '{PropertyValue}' already exist.");

        }
    }
}
