using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public abstract class BaseMapping
    {
        protected readonly ModelBuilder _modelBuilder;

        public BaseMapping(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public abstract void Map();
    }
}
