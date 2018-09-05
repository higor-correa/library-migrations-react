using Library.Domain.Entities;
using Library.Repository.Context.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AuthorMapping(modelBuilder);
            new PublishierMapping(modelBuilder);
            new BookMapping(modelBuilder);
            new AuthorBookMapping(modelBuilder);
            new BookCategoryMapping(modelBuilder);
            new UserMapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublishierEntity> Publishiers { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorBookEntity> AuthorsBooks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
