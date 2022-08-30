using FluentValidation;
using Project.Application.Email;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.DataAccess;
using Project.Implementation.Validators;

namespace Project.Implementation.UseCases.Commands
{
    public class UserRegistrationCommand : EfUseCase, IUserRegistrationCommand
    {
        private UserRegistrationValidator _validator;
        private IEmailSender _sender;

        public UserRegistrationCommand(ProjectDbContext context, UserRegistrationValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }
        public int Id => 1;
        public string Name => "Registration";
        public string Description => "";

        public void Execute(UserRegisterDTO request)
        {
            #region Validation
            _validator.ValidateAndThrow(request);
            #endregion

            #region NewUser
            var password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var newUser = new Domen.User
            {
                Username = request.Username,
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Password = password
            };

            context.Users.Add(newUser);
            context.SaveChanges();
            #endregion

            #region Email
            //_sender.Send(new EmailDTO
            //{
            //    To = request.Email,
            //    Title = "Please Confirm Your Registration",
            //    Body = $"Dear {request.Firstname}, please confirm your registration...."
            //});
            #endregion
        }
    }
}
