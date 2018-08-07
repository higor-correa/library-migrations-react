using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Library.Repository.Context.Mapping
{
    public abstract class BaseMapping<TEntity> where TEntity : BaseEntity
    {
        protected readonly ModelBuilder _modelBuilder;
        protected readonly EntityTypeBuilder<TEntity> _builder;

        public BaseMapping(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            _builder = _modelBuilder.Entity<TEntity>();

            _builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            _builder.HasKey(x => x.Id);
        }

        public abstract void Map();
    }
}
