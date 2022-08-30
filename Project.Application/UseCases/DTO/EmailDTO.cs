using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO
{
    public class EmailDTO
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
