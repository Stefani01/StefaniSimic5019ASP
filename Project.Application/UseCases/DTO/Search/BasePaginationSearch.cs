using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTO.Search
{
    public class BasePaginationSearch
    {
        public string Keyword { get; set; }
        public int PerPage { get; set; } = 3;
        public int? Page { get; set; } = 1;
    }
}
