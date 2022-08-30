using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Project.Api.Core;
using Project.Application.Email;
using Project.Application.Exceptions;
using Project.Application.UseCases;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.Commands.User;
using Project.Application.UseCases.Queries;
using Project.Application.UseCases.Queries.User;
using Project.DataAccess;
using Project.Domen;
using Project.Implementation;
using Project.Implementation.Email;
using Project.Implementation.Exceptions;
using Project.Implementation.UseCases.Commands;
using Project.Implementation.UseCases.Commands.User;
using Project.Implementation.UseCases.Queries;
using Project.Implementation.UseCases.Queries.User;
using Project.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new AppSettings();
            Configuration.Bind(settings);
            services.AddSingleton(settings);


            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "AlbumProject",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123asdhnjckfna0123")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserID") == null)
                {
                    return new AnonymousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    ID = Int32.Parse(claims.FindFirst("UserID").Value),
                    Identity = claims.FindFirst("Identity").Value,
                    UseCaseIDs = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
            #endregion
            //services.AddTransient<ProjectDbContext>();
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                optionsBuilder.UseSqlServer(@"Data Source=SIMICPC\SQLEXPRESS;Initial Catalog=ProjectASP;Integrated Security=True");

                var options = optionsBuilder.Options;

                return new ProjectDbContext(options, x.GetService<IApplicationUser>());
            });

            services.AddTransient<JwtSettings>();
            services.AddTransient<JwtManager>();

            #region UseCases
            services.AddTransient<IUserRegistrationCommand, UserRegistrationCommand>();
                #region Genres
                services.AddTransient<IGetGenresQuery, GetGenresQuery>();
                services.AddTransient<IGetGenreByIdQuery, GetGenreByIdQuery>();
                services.AddTransient<IDeleteGenreCommand, DeleteGenreCommand>();
                services.AddTransient<ICreateGenreCommand, CreateGenreCommand>();
                services.AddTransient<IUpdateGenreCommand, UpdateGenreCommand>();
                #endregion
                #region Artists
                services.AddTransient<IGetArtistsQuery, GetArtistsQuery>();
                services.AddTransient<IGetArtistByIdQuery, GetArtistByIdQuery>();
                services.AddTransient<ICreateArtistCommand, CreateArtistCommand>();
                services.AddTransient<IUpdateArtistCommand, UpdateArtistCommand>();
                services.AddTransient<IDeleteArtistCommand, DeleteArtistCommand>();
                #endregion
                #region Likes
                services.AddTransient<ICreateLikeCommand, CreateLikeCommand>();
                services.AddTransient<IDeleteLikeCommand, DeleteLikeCommand>();
                #endregion
                #region Albums
                services.AddTransient<IGetAlbumsQuery, GetAlbumsQuery>();
                services.AddTransient<IGetAlbumByIdQuery, GetAlbumByIdQuery>();
                services.AddTransient<IDeleteAlbumCommand, DeleteAlbumCommand>();
                services.AddTransient<ICreateAlbumCommand, CreateAlbumCommand>();
                services.AddTransient<IUpdateAlbumCommand, UpdateAlbumCommand>();
                #endregion
                #region Songs
                services.AddTransient<IGetSongsQuery, GetSongsQuery>();
                    services.AddTransient<IGetSongByIdQuery, GetSongByIdQuery>();
                    services.AddTransient<ICreateSongCommand, CreateSongCommand>();
                    services.AddTransient<IUpdateSongCommand, UpdateSongCommand>();
                    services.AddTransient<IDeleteSongCommand, DeleteSongCommand>();
            #endregion
                #region User
                services.AddTransient<ICreateUserUseCasesCommand, CreateUserUseCasesCommand>();
                services.AddTransient<IUpdateUserUseCasesCommand, UpdateUserUseCasesCommand>();
                services.AddTransient<ISearchLogQuery, SearchLogQuery>();
                services.AddTransient<IGetUsersQuery, GetUsersQuery>();
                services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
                services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
                #endregion
                #region Order
                services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
                    services.AddTransient<IDeleteOrderCommand, DeleteOrderCommand>();
                    #endregion
                #endregion

            #region Validators
            services.AddTransient<UserRegistrationValidator>();
            services.AddTransient<CreateGenreValidator>();
            services.AddTransient<CreateArtistValidator>();
            services.AddTransient<CreateLikeValidator>();
            services.AddTransient<CreateSongValidator>();
            services.AddTransient<CreateAlbumValidator>();
            services.AddTransient<UserUseCaseValidator>();
            services.AddTransient<OrderValidator>();
            #endregion

            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<IEmailSender>(x => new EmailSender(settings.EmailFrom, settings.EmailPassword));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project.Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project.Api v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
