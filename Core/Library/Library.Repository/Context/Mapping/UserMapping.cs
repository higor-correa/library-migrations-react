using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public class UserMapping : BaseMapping<UserEntity>
    {
        public UserMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        { }

        public override void Map()
        {
            _builder.Property(x => x.Login)
               .IsRequired()
               .HasMaxLength(10);

            _builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(20);

            _builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            _builder.Property(x => x.Active)
                .HasDefaultValue(true)
                .IsRequired();

            _builder.HasAlternateKey(x => x.Login);
        }
    }
}
