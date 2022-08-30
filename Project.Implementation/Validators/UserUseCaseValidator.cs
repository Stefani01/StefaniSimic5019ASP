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
    public class UserUseCaseValidator : AbstractValidator<UseCaseDTO>
    {
        public UserUseCaseValidator(ProjectDbContext context)
        {
            RuleFor(x => x.UserID)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("User is required.")
                .Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User with ID: {PropertyValue} doesn't exist.");

            RuleFor(x => x.UseCaseIDs)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Use cases are required.")
                .Must(x => x.Count() == x.Distinct().Count()).WithMessage("Duplicate Use Case IDs are not allowed.");
        }
    }
}
