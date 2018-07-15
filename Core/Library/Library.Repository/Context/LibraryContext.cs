using Library.Domain.Entities;
using Library.Repository.Context.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Library.Repository.Context
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions options) : base(options)
        {           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mappings = new List<BaseMapping>
            {
                new AuthorMapping(modelBuilder),
                new PublishierMapping(modelBuilder),
                new BookMapping(modelBuilder),
                new AuthorBookMapping(modelBuilder),
                new BookCategoryMapping(modelBuilder)
            };

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublishierEntity> Publishiers { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorBookEntity> AuthorsBooks { get; set; }
    }
}
