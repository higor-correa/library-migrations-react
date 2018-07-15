﻿using AutoMapper;
using Library.Bll;
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
        }

        public static void AddAutoMapper(this IServiceCollection service)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainProfile>();
            });
        }
    }
}