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
    public class GetArtistsQuery : EfUseCase, IGetArtistsQuery
    {
        public GetArtistsQuery(ProjectDbContext context) : base(context)
        {
        }
        public int Id => 7;
        public string Name => "Search artist";
        public string Description => "";

        public PaginationResponse<ArtistDTO> Execute(BasePaginationSearch request)
        {
            var query = context.Artists.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Fullname.Contains(request.Keyword));

            if (request.PerPage < 1)
                request.PerPage = 3;

            if (request.Page == null || request.Page < 1)
                request.Page = 1;

            var response = new PaginationResponse<ArtistDTO>();
            response.TotalCount = query.Count();

            var toSkip = (request.Page.Value - 1) * request.PerPage;
            response.Data = query.Skip(toSkip).Take(request.PerPage).Select(x => new ArtistDTO
                {
                    Work = x.Albums.Select(x => new ArtistAlbumSongsDTO
                    {
                        Album = x.Name,
                        Songs = x.Songs.Select(x => new ArtistSongDTO
                        {
                            Name = x.Name
                        })
                    }),
                    ID = x.Id,
                    Name = x.Fullname
                }).ToList();

            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage;

            return response;
        }
    }
}
