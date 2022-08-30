using Microsoft.EntityFrameworkCore;
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
    public class GetSongsQuery : EfUseCase, IGetSongsQuery
    {
        public GetSongsQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Get albums";

        public string Description => "";

        public PaginationResponse<SongDTO> Execute(BasePaginationSearch request)
        {
            var query = context.Songs.Include(x => x.Artists).Include(x => x.Album).Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword)
                             || x.Artists.Any(x => x.Artist.Fullname.Contains(request.Keyword)));

            if (request.PerPage < 1)
                request.PerPage = 3;

            if (request.Page == null || request.Page < 1)
                request.Page = 1;

            var response = new PaginationResponse<SongDTO>();
            response.TotalCount = query.Count();

            var toSkip = (request.Page.Value - 1) * request.PerPage;
            response.Data = query.Skip(toSkip).Take(request.PerPage).Select(x => new SongDTO
            {
                ID = x.Id,
                Name = x.Name,
                Duration = x.Duration,
                Artists = x.Artists.Select(x=>x.Artist.Fullname),
                Album = x.Album.Name
            });

            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage;
            return response;
        }
    }
}
