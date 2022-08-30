using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Project.Application.Exceptions;
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
    public class UpdateGenreCommand : EfUseCase, IUpdateGenreCommand
    {
        private CreateGenreValidator _validator;
        public UpdateGenreCommand(ProjectDbContext context, CreateGenreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;
        public string Name => "Update genre";
        public string Description => "";

        public void Execute(UpdateGenreDTO request)
        {
            if (request.GenreID <= 0)
                throw new ConflictException("Genre ID must be greater than 0.");

            var genre = context.Genres.FirstOrDefault(x => x.IsActive && x.Id == request.GenreID);
            if (genre == null)
                throw new EntityNotFoundException(nameof(Genre), request.GenreID);

            _validator.ValidateAndThrow(request);
            genre.Name = request.Name;
         
            context.SaveChanges();
        }
    }
}
