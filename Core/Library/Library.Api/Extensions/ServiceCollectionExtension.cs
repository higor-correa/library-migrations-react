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
using Library.Bll.User;
using Library.Bll.User.Interfaces;
using Library.Domain.AutoMapperProfiles;
using Library.Repository;
using Library.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddLibrary(this IServiceCollection service)
        {
            service.AddScoped<IAuthorBll, AuthorBll>();
            service.AddScoped<IAuthorRepository, AuthorRepository>();

            service.AddScoped<IBookPublishValidator, BookPublishValidator>();
            service.AddScoped<IBookBll, BookBll>();
            service.AddScoped<IPublishBookBll, PublishBookBll>();
            service.AddScoped<IBookRepository, BookRepository>();

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
    }
}
