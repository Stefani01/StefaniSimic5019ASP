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
    public class CreateAlbumValidator : AbstractValidator<CreateAlbumDTO>
    {
        public CreateAlbumValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Price is required.")
                                    .InclusiveBetween(1, 100).WithMessage("Price must be between $1 and $100");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Album name can't have less than 2 characters.")
                .MaximumLength(50).WithMessage("Album name can't have more than 50 characters.");

            RuleFor(x => x.Published).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Published date is required. (dd/mm/yyyy)")
                .Must(x => DateTime.Compare(DateTime.ParseExact(x, "dd/MM/yyyy", null), DateTime.UtcNow) <= 0).WithMessage("Published date can't be in the future. (dd/mm/yyyy)");

            RuleFor(x => x.ArtistID).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Artist ID is required.")
                .Must(x => context.Artists.Any(y => y.Id == x)).WithMessage("Artist don't exist in system.");
                
            RuleFor(x=>x.GenreIDs).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Genre is required.")
                .Must(x =>
                {
                    if (x == null)
                        return true;
                    return x.Distinct().Count() == x.Count();
                }).WithMessage("You need to insert distinct Genre IDs.");
            RuleForEach(x => x.GenreIDs).Must(x => context.Genres.Any(y => y.Id == x)).WithMessage("Genre don't exist in system.");
        }
    }
}
