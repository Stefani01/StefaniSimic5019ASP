using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.Queries
{
    public class PaginationResponse<T>
        where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
        public IEnumerable<T> Data { get; set; }
    }
}
