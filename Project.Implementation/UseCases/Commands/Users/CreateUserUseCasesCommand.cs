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
    public class CreateUserUseCasesCommand : EfUseCase, ICreateUserUseCasesCommand
    {
        private UserUseCaseValidator _validator;
        public CreateUserUseCasesCommand(ProjectDbContext context, UserUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 24;
        public string Name => "Add use case to user";
        public string Description => "";

        public void Execute(UseCaseDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cases = request.UseCaseIDs.Select(x => new UseCase
            {
                UseCaseID = x,
                UserID = request.UserID
            });

            context.UseCases.AddRange(cases);
            context.SaveChanges();
        }
    }
}
