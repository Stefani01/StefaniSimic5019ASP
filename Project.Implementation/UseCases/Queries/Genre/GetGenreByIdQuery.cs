using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class GetGenreByIdQuery : EfUseCase, IGetGenreByIdQuery
    {
        public GetGenreByIdQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 3;
        public string Name => "Find genre";
        public string Description => "Get genre by ID";

        public GenreDTO Execute(int request)
        {
            var genre = context.Genres.Include(x => x.Albums)
                                      .FirstOrDefault(x => x.IsActive && x.Id == request);

            if(genre == null)
                throw new EntityNotFoundException(nameof(Genre), request);

            return new GenreDTO
            {
                ID = request,
                Name = genre.Name,
                NumberOfAlbums = genre.Albums.Count()
            };
        }
    }
}
