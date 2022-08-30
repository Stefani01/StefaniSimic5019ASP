using Project.Application.UseCases.DTO;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class GetGenresQuery : EfUseCase, IGetGenresQuery
    {
        public GetGenresQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 2;
        public string Name => "Get Genres";
        public string Description => "Search genres by name.";

        public PaginationResponse<GenreDTO> Execute(BasePaginationSearch request)
        {   
            var query = context.Genres.Where(x => x.IsActive);
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));

            if (request.PerPage < 1)
                request.PerPage = 3;

            if (request.Page == null || request.Page < 1)
                request.Page = 1;

            var response = new PaginationResponse<GenreDTO>();
            response.TotalCount = query.Count();

            var toSkip = (request.Page.Value - 1) * request.PerPage;
            response.Data = query.Skip(toSkip).Take(request.PerPage).Select(x => new GenreDTO
            {
                ID = x.Id,
                Name = x.Name,
                NumberOfAlbums = x.Albums.Count()
            }).ToList();

            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage;

            return response;
        }
    }
}
