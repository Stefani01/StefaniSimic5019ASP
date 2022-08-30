using Project.Application.Exceptions;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Commands
{
    public class DeleteLikeCommand : EfUseCase, IDeleteLikeCommand
    {
        public IApplicationUser user;
        public DeleteLikeCommand(ProjectDbContext context, IApplicationUser user) : base(context)
        {
            this.user = user;
        }

        public int Id => 19;
        public string Name => "Delete like";
        public string Description => "";

        public void Execute(LikeDTO request)
        {
            var like = context.Likes.FirstOrDefault(x => x.UserID == this.user.ID && x.AlbumID == request.AlbumID && x.IsActive);

            if (like == null)
                throw new ConflictException("Like don't exist.");

            context.Likes.Remove(like);
            context.SaveChanges();
        }
    }
}
