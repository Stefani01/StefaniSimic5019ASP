using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateUserUseCasesCommand : EfUseCase, IUpdateUserUseCasesCommand
    {
        private UserUseCaseValidator _validator;
        public UpdateUserUseCasesCommand(ProjectDbContext context, UserUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;
        public string Name => "Update user use cases";
        public string Description => "";

        public void Execute(UseCaseDTO request)
        {
            _validator.ValidateAndThrow(request);
            var userUseCases = context.UseCases.Where(x => x.UserID == request.UserID).ToList();

            context.UseCases.RemoveRange(userUseCases);

            var newUseCases = request.UseCaseIDs.Select(x => new UseCase
            {
                UseCaseID = x,
                UserID = request.UserID
            });

            context.UseCases.AddRange(newUseCases);
            context.SaveChanges();
        }
    }
}
