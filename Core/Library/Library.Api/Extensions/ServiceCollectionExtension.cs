using AutoMapper;
using Library.Bll.Author;
using Library.Bll.Author.Interfaces;
using Library.Bll.Book;
using Library.Bll.Book.Interfaces;
using Library.Bll.Book.Validators;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.BookCategory.Types;
using Library.Bll.BookCategory.Types.Interface;
using Library.Bll.Publisher;
using Library.Bll.Publisher.Interfaces;
using Library.Bll.Settings;
using Library.Bll.Settings.Interfaces;
using Library.Bll.User;
using Library.Bll.User.Interfaces;
using Library.Bll.User.Token;
using Library.Bll.User.Token.Interfaces;
using Library.Domain.AutoMapperProfiles;
using Library.Repository;
using Library.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddLibrary(this IServiceCollection service)
        {
            
            service.AddScoped<IAppSettings, AppSettings>();
            service.AddScoped<IAuthorBll, AuthorBll>();
            service.AddScoped<IAuthorRepository, AuthorRepository>();

            service.AddScoped<IBookPublishValidator, BookPublishValidator>();
            service.AddScoped<IBookBll, BookBll>();
            service.AddScoped<IPublishBookBll, PublishBookBll>();
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<ILoginBll, LoginBll>();
            service.AddScoped<ITokenManager, TokenManager>();

            service.AddScoped<IUserBll, UserBll>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<IBookCategoryTypesBll, BookCategoryTypesBll>();

            service.AddScoped<IPublishierBll, PublisherBll>();
            service.AddScoped<IPublishierRepository, PublishierRepository>();
        }

        public static void AddAutoMapper(this IServiceCollection service)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AuthorProfile>();
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<BookCategoryProfile>();
                cfg.AddProfile<PublishierProfile>();
                cfg.AddProfile<UserProfile>();
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection service, string privateKey)
        {
            var key = Encoding.ASCII.GetBytes(privateKey);

            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            service.AddAuthorization(x =>
            {
                x.AddPolicy("Bearer", policy => 
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                          .RequireAuthenticatedUser().Build());
            });
        }
    }
}
