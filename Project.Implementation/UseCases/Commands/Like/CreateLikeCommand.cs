using FluentValidation;
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
    public class CreateLikeCommand : EfUseCase, ICreateLikeCommand
    {
        private CreateLikeValidator _validator;
        public IApplicationUser user;
        public CreateLikeCommand(ProjectDbContext context, CreateLikeValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            this.user = user;
        }
        public int Id => 11;
        public string Name => "Like album";
        public string Description => "";

        public void Execute(LikeDTO request)
        {
            _validator.ValidateAndThrow(request);

            var alreadyLiked = context.Likes.FirstOrDefault(x => x.UserID == this.user.ID 
                                                                    && x.AlbumID == request.AlbumID 
                                                                                        && x.IsActive);

            if (alreadyLiked != null)
                throw new ConflictException("You already liked album.");

            var like = new Like
            {
                UserID = this.user.ID,
                AlbumID = request.AlbumID
            };

            context.Likes.Add(like);
            context.SaveChanges();
        }
    }
}
