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
    public class CreateSongValidator : AbstractValidator<CreateSongDTO>
    {
        public CreateSongValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Song name is required")
                .MaximumLength(70).WithMessage("Song name can't have more than 70 characters.");
            RuleFor(x => x.AlbumID).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Album ID is required")
                .Must(x => context.Albums.Any(a => a.Id == x)).WithMessage("Album ID don't exist in system.");
            RuleFor(x => x.ArtistIDs).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Artist ID is required.")
                .Must(x =>
                {
                    if (x == null)
                        return true;
                    return x.Distinct().Count() == x.Count();
                }).WithMessage("You need to insert distinct artist IDs.");
            RuleForEach(x => x.ArtistIDs).Must(x => context.Artists.Any(a => a.Id == x)).WithMessage("Artist ID don't existin system");
        }
    }
}
