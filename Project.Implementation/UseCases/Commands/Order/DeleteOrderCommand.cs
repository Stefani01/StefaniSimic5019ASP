using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Commands
{
    public class DeleteOrderCommand : EfUseCase, IDeleteOrderCommand
    {
        public IApplicationUser user;
        public DeleteOrderCommand(ProjectDbContext context, IApplicationUser user) : base(context)
        {
            this.user = user;
        }

        public int Id => 28;
        public string Name => "Delete item from order";
        public string Description => "";

        public void Execute(int request)
        {
            var item = context.OrderLines.Include(x => x.Order)
                .FirstOrDefault(x => x.IsActive && x.Order.UserID == this.user.ID && x.AlbumID == request);

            if (item == null)
                throw new ConflictException($"Album with ID: {request} is not placed in order for user with ID: {this.user.ID}.");

            context.OrderLines.Remove(item);
            context.SaveChanges();
        }
    }
}
