﻿using Project.Application.UseCases.DTO.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.Queries
{
    public interface ISearchLogQuery : IQuery<UseCaseLogSearch, IEnumerable<UseCaseLogApp>>
    {
    }
}
