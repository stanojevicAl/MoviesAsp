using Application;
using Application.Interfaces;
using DataAccess;
using Implementation.Commands;
using Implementation.Commands.MovieCommands;
using Implementation.Commands.UserCommands;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUsesCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseExecutor>();

            //create commands
            services.AddTransient<CreateActorCommand>();
            services.AddTransient<CreateGenreCommand>();
            services.AddTransient<CreateMovieCommand>();
            services.AddTransient<CreateUserCommand>();
            services.AddTransient<CommantMovieCommand>();
            services.AddTransient<RatingMovieCommand>();
            services.AddTransient<FavoriteMovieCommand>();

            //update commands
            services.AddTransient<UpdateMovieCommand>();
            services.AddTransient<UpdateActorCommand>();
            services.AddTransient<UpdateGenreCommand>();
            services.AddTransient<UpdateUserCommand>();
            services.AddTransient<VerificationCommand>();

            //delete commands
            services.AddTransient<DeleteMovieCommand>();
            services.AddTransient<DeleteActorCommand>();
            services.AddTransient<DeleteGenreCommand>();
            services.AddTransient<DeleteUserCommand>();
            services.AddTransient<DeleteFavoriteCommand>();

            //create validators
            services.AddTransient<CreateActorValidator>();
            services.AddTransient<CreateGenreValidator>();
            services.AddTransient<CreateMovieValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<CommentValidator>();
            services.AddTransient<RatingValidator>();

            //update validators
            services.AddTransient<UpdateMovieValidator>();
            services.AddTransient<UpdateActorValidator>();
            services.AddTransient<UpdateGenreValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<VerificationValidator>();

            //queries
            services.AddTransient<GetMoviesQuery>();
            services.AddTransient<GetActorQuery>();
            services.AddTransient<GetGenreQuery>();
            services.AddTransient<GetUserQuery>();
            services.AddTransient<GetLoggetQuery>();
            services.AddTransient<GetFavoriteQuery>();
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("UserData") == null)
                {
                    return new UnregisteredUser();
                }

                var userString = user.FindFirst("UserData").Value;

                var userJwt = JsonConvert.DeserializeObject<JwtUser>(userString);

                return userJwt;
            });
        }

        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<Context>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });
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
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
