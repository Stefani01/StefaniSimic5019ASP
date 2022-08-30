using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.Queries.User;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries.User
{
    public class GetUserByIdQuery : EfUseCase, IGetUserByIdQuery
    {
        public GetUserByIdQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Get user by ID";

        public string Description => "";

        public UserDTO Execute(int request)
        {
            var user = context.Users.Include(x => x.UseCases).Include(x => x.Orders).Include(x => x.Likes).FirstOrDefault(x => x.IsActive && x.Id == request);

            if (user == null)
                throw new EntityNotFoundException(nameof(User), request);

            return new UserDTO
            {
                Id = user.Id,
                FullName = $"{user.Firstname} {user.Lastname}",
                Username = user.Username,
                Email = user.Email,
                UserFrom = user.CreatedAt.ToString("MMMM dd, yyyy"),
                AlbumLikes = user.Likes.Count(),
                Orders = user.Orders.Count(),
                UseCaseIDs = user.UseCases.Select(x => x.UseCaseID)
            };
        }
    }
}
