using Library.Bll.Book.Validators.Interface;
using Library.Bll.Book.Validators.Strategies;
using Library.Bll.Exceptions;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Bll.Book.Validators
{
    public class BookPublishValidator : IBookPublishValidator
    {
        private List<IBookValidationStrategy> _validationStrategies;

        public BookPublishValidator()
        {
            _validationStrategies = new List<IBookValidationStrategy>
            {
                new EntitiesNotFoundStrategy(),
                new BookAlreadyPublishedStrategy(),
                new BookAuthorsValidationStrategy()
            };
        }

        public void ValidatePublish(BookEntity book, PublishierEntity publisher)
        {
            var erros = new List<string>();
            
            foreach (var strategy in _validationStrategies)
                erros.AddRange(strategy.Validate(book, publisher));

            if (erros.Any())
                throw new BusinessException(string.Join(Environment.NewLine, erros));
        }
    }
}
