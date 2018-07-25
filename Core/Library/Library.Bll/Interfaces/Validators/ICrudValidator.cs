using Library.Bll.Enums;
using Library.Domain.Entities;

namespace Library.Bll.Interfaces.Validators
{
    public interface ICrudValidator<TEntity>
        where TEntity : BaseEntity
    {
        void Validate(OperationTypeEnum operationType);
    }
}
