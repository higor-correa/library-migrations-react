﻿using FluentValidation.AspNetCore;
using Library.Api.ExceptionsHandler;
using Library.Bll.Validators.DTO.Author;
using Library.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Api
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

            services.AddMvc()
                    .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<AuthorRequestDTOValidator>());

            new Bootstrapper(services, Configuration).Register();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ExceptionHandler));

            app.UseAuthentication();

            app.UseMvc();

            context.Database.Migrate();
        }

        //TODO-: Livro não pode ter mais de 3 autores
        //TODO-: Autor que não possui uma editora vinculada não pode publicar o livro
        //TODO-: Livro ao ser publicado deve ser da editora de algum dos autores
        //TODO-: Colocar data de publicação no livro pra mexer com data no front
        //TODO-: Permitir cancelar a publicação do livro
        //TODO: OAuth? + Usuarios
    }
}
