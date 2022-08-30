using Microsoft.EntityFrameworkCore;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.Application.UseCases.Queries.User;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries.User
{
    public class GetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public GetUsersQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 29;

        public string Name => "Get registered users.";

        public string Description => "";

        public PaginationResponse<UserDTO> Execute(BasePaginationSearch request)
        {
            var query = context.Users.Include(x => x.UseCases).Include(x => x.Orders).Include(x => x.Likes).Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Firstname.Contains(request.Keyword)
                                            || x.Lastname.Contains(request.Keyword)
                                            || x.Username.Contains(request.Keyword));

            if (request.PerPage < 1)
                request.PerPage = 3;

            if (request.Page == null || request.Page < 1)
                request.Page = 1;

            var response = new PaginationResponse<UserDTO>();
            response.TotalCount = query.Count();

            var toSkip = (request.Page.Value - 1) * request.PerPage;
            response.Data = query.Select(x => new UserDTO
            {
                Id = x.Id,
                FullName = $"{x.Firstname} {x.Lastname}",
                Username = x.Username,
                Email = x.Email,
                UserFrom = x.CreatedAt.ToString("MMMM dd, yyyy"),
                AlbumLikes = x.Likes.Count(),
                Orders = x.Orders.Count(),
                UseCaseIDs = x.UseCases.Select(x=>x.UseCaseID)
            });
            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage;

            return response;
        }
    }
}
