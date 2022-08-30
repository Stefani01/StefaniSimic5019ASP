using Project.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.Commands
{
    public interface IUpdateAlbumCommand : ICommand<UpdateAlbumDTO>
    {
    }
}
