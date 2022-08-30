using Microsoft.EntityFrameworkCore;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class GetAlbumsQuery : EfUseCase, IGetAlbumsQuery
    {
        public GetAlbumsQuery(ProjectDbContext context) : base(context)
        {
        }
        public int Id => 12;
        public string Name => "Search albums";

        public string Description => "Search albums by keyword, min price and max price";

        public PaginationResponse<AlbumDTO> Execute(AlbumSearch request)
        {
            var query = context.Albums.Include(x=>x.Songs).Include(x=>x.Genres).Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword)
                                         || x.Songs.Any(s => s.Name.Contains(request.Keyword))
                                            || x.Artist.Fullname.Contains(request.Keyword));
                               
            if (request.MaxPrice.HasValue)
                query = query.Where(x => x.Price <= request.MaxPrice);

            if(request.MinPrice.HasValue)
                query = query.Where(x => x.Price >= request.MinPrice);

            if (request.PerPage < 1)
                request.PerPage = 3;

            if (request.Page == null || request.Page < 1)
                request.Page = 1;

            var response = new PaginationResponse<AlbumDTO>();
            response.TotalCount = query.Count();

            var toSkip = (request.Page.Value - 1) * request.PerPage;
            response.Data = query.Skip(toSkip).Take(request.PerPage).Select(x => new AlbumDTO
            {
                ID = x.Id,
                Name = x.Name,
                Price = x.Price.ToString("C", CultureInfo.CurrentCulture),
                Published = x.Published.ToString("MMMM dd, yyyy"),
                Image = (x.ImagePath != null) ? x.ImagePath : "/",
                Likes = x.Likes.Count(),
                Songs = x.Songs.Select(x=> new AlbumSongsDTO
                {
                    ID=x.Id,
                    Name = x.Name
                }).ToList(),
                Artist = x.Artist.Fullname,
                Genres = x.Genres.Select(x=>x.Genre.Name)
            });
            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage;

            return response;
        }
    }
}
