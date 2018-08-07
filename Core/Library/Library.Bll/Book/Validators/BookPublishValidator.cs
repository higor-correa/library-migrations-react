using System;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Exceptions;
using Library.Domain.DTO.Book;
using Library.Repository.Interfaces;

namespace Library.Bll.Book.Validators
{
    public class BookPublishValidator : IBookPublishValidator
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishierRepository _publishierRepository;

        public BookPublishValidator(IBookRepository bookRepository, IPublishierRepository publishierRepository)
        {
            _bookRepository = bookRepository;
            _publishierRepository = publishierRepository;
        }

        public void ValidatePublish(Guid? id, PublishBookRequestDTO publishBookRequest)
        {
            var book = _bookRepository.Get(id.GetValueOrDefault());
            if (book == null)
                throw new EntityNotFoundException($"Book ({id})");

            var publishier = _publishierRepository.Get(publishBookRequest.PublishierId.GetValueOrDefault());
            if (publishier == null)
                throw new BusinessException($"Publishier {publishBookRequest.PublishierId} couldn't be found");
        }
    }
}
