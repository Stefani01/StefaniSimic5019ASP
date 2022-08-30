using FluentValidation;
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
    public class CreateGenreCommand : EfUseCase, ICreateGenreCommand
    {
        private CreateGenreValidator _validator;
        public CreateGenreCommand(ProjectDbContext context, CreateGenreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;
        public string Name => "Create genre";
        public string Description => "";

        public void Execute(CreateGenreDTO request)
        {
            _validator.ValidateAndThrow(request);
            var newGenre = new Genre
            {
                Name = request.Name
            };

            context.Genres.Add(newGenre);
            context.SaveChanges();
        }
    }
}
