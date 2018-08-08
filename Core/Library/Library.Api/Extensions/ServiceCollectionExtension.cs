﻿using AutoMapper;
using Library.Bll;
using Library.Bll.Book;
using Library.Bll.Book.Validators;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Interfaces;
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
            service.AddScoped<IBookRepository, BookRepository>();

            service.AddScoped<IBookCategoryEnumBll, BookCategoryEnumBll>();

            service.AddScoped<IPublishierBll, PublishierBll>();
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
            });
        }
    }
}
