using AutoMapper;
using Library.Bll.Settings.Extensions;
using Library.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.Bll.Test.Integration
{
    public abstract class LibraryIntegrationTestBase
    {
        private IServiceCollection _services;
        private ServiceProvider _serviceProvider;
        private LibraryContext _context;

        public LibraryIntegrationTestBase()
        {
            DependencyInjection();
            MockDb();
            GenerateProvider();
            ResolveDatabase();
        }

        private void MockDb()
        {
            _services.AddDbContext<LibraryContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        }

        private void DependencyInjection()
        {
            _services = new ServiceCollection();
            _services.AddLibrary();
            try
            {
                Mapper.Reset();
                _services.AddAutoMapper();
            }
            catch (Exception) {/*AutoMapper singleton already initialized :D*/}
        }

        private void GenerateProvider()
        {
            _serviceProvider = _services.BuildServiceProvider();
        }

        private void ResolveDatabase()
        {
            _context = Resolve<LibraryContext>();
        }

        protected T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        protected void AddEntities(params object[] entities)
        {
            foreach (var entity in entities)
                _context.Add(entity);
            _context.SaveChanges();
        }

        protected void RemoveEntities(params object[] entities)
        {
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                    _context.Attach(entity);

                _context.Remove(entity);
            }
            _context.SaveChanges();
        }

        protected void Commit()
        {
            _context.SaveChanges();
        }
    }
}
