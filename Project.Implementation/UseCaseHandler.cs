using Newtonsoft.Json;
using Project.Application.Exceptions;
using Project.Application.UseCases;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;
        private IApplicationUser _user;
        private IUseCaseLogger _useCaseLogger;
        private ProjectDbContext _context;
        public UseCaseHandler(IExceptionLogger logger, IApplicationUser user, IUseCaseLogger useCaseLogger, ProjectDbContext context)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
            _context = context;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            { 
                HandleLoggingAndAuthorization(command, data);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + ", Duration: " + stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = query.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(query.Name + ", Duration: " + stopwatch.ElapsedMilliseconds);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var log = new UseCaseLogApp
            {
                User = _user.Identity,
                ExecutionTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserID = _user.ID,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = _user.UseCaseIDs.Contains(useCase.Id)
            };

            _useCaseLogger.Log(log);

            var dbLog = new UseCaseLog
            {
                Username = _user.Identity,
                ExecutionTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserID = (_user.ID == 0) ? null : _user.ID,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = _user.UseCaseIDs.Contains(useCase.Id)
            };
            _context.UseCaseLogs.Add(dbLog);
            _context.SaveChanges();

            if (!log.IsAuthorized)
            {
                throw new ForbiddenUsecaseExecutionException(useCase.Name, _user.Identity);
            }
        }
    }
}
