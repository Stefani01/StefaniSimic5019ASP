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
    public class CreateLikeValidator : AbstractValidator<LikeDTO>
    {
        public CreateLikeValidator(ProjectDbContext context)
        {

            RuleFor(x => x.AlbumID).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Album ID is required.")
                                  .GreaterThanOrEqualTo(0).WithMessage("Album ID must be greater than 0.")
                                  .Must(x => context.Albums.Any(a => a.Id == x)).WithMessage("Album ID must exist in system");
        }
    }
}
