using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO.Search
{
    public class UseCaseLogSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string UseCaseName { get; set; }
        public string Username { get; set; }
    }
}
