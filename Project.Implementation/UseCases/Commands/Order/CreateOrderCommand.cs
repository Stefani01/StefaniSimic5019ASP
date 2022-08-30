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
    public class CreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private OrderValidator _validator;
        public IApplicationUser user;
        public CreateOrderCommand(ProjectDbContext context, OrderValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            this.user = user;
        }

        public int Id => 27;
        public string Name => "Order create";
        public string Description => "";

        public void Execute(OrderDTO request)
        {
            _validator.ValidateAndThrow(request);

            var placeNewOrder = new Order
            {
                CreditCard = request.CreditCardNumber,
                UserID = this.user.ID
            };

            var orderItems = request.AlbumIDs.Select(x => new OrderLine
            {
                AlbumID = x,
                Quantity = 1,
                Order = placeNewOrder
            });
            
            context.OrderLines.AddRange(orderItems);
            context.SaveChanges();
        }
    }
}
