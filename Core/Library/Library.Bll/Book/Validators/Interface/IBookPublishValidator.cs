using Library.Domain.DTO.Book;
using System;

namespace Library.Bll.Book.Validators.Interface
{
    public interface IBookPublishValidator
    {
        void ValidatePublish(Guid? id, PublishBookRequestDTO publishBookRequest);
    }
}
