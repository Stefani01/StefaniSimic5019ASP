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
  
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator(ProjectDbContext context)
        {
            RuleFor(x => x.CreditCardNumber).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Credit card number is required.")
                .Matches(@"(\d{4} *\d{4} *\d{4} *\d{4})").WithMessage("{PropertyValue} is not valid credit card number. (1234 4567 7891 1234)");

            RuleFor(x => x.AlbumIDs)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Album is required.")
                .Must(x =>
                {
                    if (x == null)
                        return true;
                    return x.Distinct().Count() == x.Count();
                }).WithMessage("You need to insert distinct Album IDs.");
            RuleForEach(x => x.AlbumIDs).Must(x => context.Albums.Any(y => y.Id == x)).WithMessage("Album don't exist in system.");
        }
    }
}
