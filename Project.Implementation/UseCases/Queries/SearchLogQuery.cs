using Project.Application.UseCases;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.UseCases.Queries
{
    public class SearchLogQuery : EfUseCase, ISearchLogQuery
    {
        public SearchLogQuery(ProjectDbContext context) : base(context)
        {
        }
        public int Id => 26;
        public string Name => "Search logs";
        public string Description => "";

        public IEnumerable<UseCaseLogApp> Execute(UseCaseLogSearch request)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if(!string.IsNullOrEmpty(request.Username))
                query = query.Where(x => x.Username == request.Username);

            if(!string.IsNullOrEmpty(request.UseCaseName))
                query = query.Where(x => x.UseCaseName == request.UseCaseName);

            if(request.DateFrom.HasValue)
                query = query.Where(x => x.ExecutionTime > request.DateFrom.Value);

            if (request.DateTo.HasValue)
                query = query.Where(x => x.ExecutionTime < request.DateTo.Value);

            return query.Select(x => new UseCaseLogApp
            {
                User = x.Username,
                UserID = x.UserID.Value,
                Data = x.Data,
                ExecutionTime = x.ExecutionTime,
                IsAuthorized = x.IsAuthorized,
                UseCaseName = x.UseCaseName
            });
        }
    }
}
