using Library.Bll.Enums;
using Library.Bll.Interfaces.Validators;
using Library.Domain.Entities;

namespace Library.Bll.Validators
{
    public abstract class BaseValidator<TEntity> : ICrudValidator<TEntity>
        where TEntity : BaseEntity
    {
        public void Validate(OperationTypeEnum operationType)
        {
            switch (operationType)
            {
                case OperationTypeEnum.Insert:
                    ValidateInsert();
                    break;
                case OperationTypeEnum.Update:
                    ValidateUpdate();
                    break;
                case OperationTypeEnum.Delete:
                    ValidateDelete();
                    break;
            }
        }

        protected abstract void ValidateUpdate();
        protected abstract void ValidateInsert();
        protected abstract void ValidateDelete();
    }
}
