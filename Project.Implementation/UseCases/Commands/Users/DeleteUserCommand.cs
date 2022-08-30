using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.Commands.User;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Commands.User
{
    public class DeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public DeleteUserCommand(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Delete user";

        public string Description => "";

        public void Execute(int request)
        {
            var user = context.Users.Include(x => x.UseCases).Include(x => x.Orders).Include(x => x.Likes).FirstOrDefault(x => x.IsActive && x.Id == request);

            if (user == null)
                throw new EntityNotFoundException(nameof(User), request);

            context.UseCases.RemoveRange(user.UseCases);
            context.Orders.RemoveRange(user.Orders);
            context.Likes.RemoveRange(user.Likes);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
