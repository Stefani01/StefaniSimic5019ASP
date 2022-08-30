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
    public class UserRegistrationValidator : AbstractValidator<UserRegisterDTO>
    {
        public UserRegistrationValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Firstname).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(30).WithMessage("First name can't have more than 30 characters.")
                .Matches(@"([A-Z][a-z]+)(\s[A-Z][a-z])*").WithMessage("First name need to start with capital letter.");

            RuleFor(x => x.Lastname).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(30).WithMessage("Last name can't have more than 30 characters.")
                .Matches(@"([A-Z][a-z]+)(\s[A-Z][a-z])*").WithMessage("Last name need to start with capital letter.");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email address: '{PropertyValue}' is not valid.")
                .Matches(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$").WithMessage("Email address: '{PropertyValue}' is not valid")
                .Must(x => !context.Users.Any(y => y.Email == x)).WithMessage("Account with email: '{PropertyValue}' already exist.");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$").WithMessage("Password must contain minimum 8 characters, at least one letter, one number and one special character"); 

            RuleFor(x => x.Username).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(15).WithMessage("Username can't have more than 15 characters.")
                .MinimumLength(3).WithMessage("Username can't have less than 3 characters.")
                .Must(x => !context.Users.Any(y => y.Username == x)).WithMessage("Account with username: '{PropertyValue}' already exist.");
        }
    }
}
