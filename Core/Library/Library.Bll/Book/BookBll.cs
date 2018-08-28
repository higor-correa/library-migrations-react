using AutoMapper;
using Library.Bll.Book.Interfaces;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Exceptions;
using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Bll.Book
{
    public class BookBll : IBookBll
    {
        private readonly IBookRepository _repository;
        private readonly IPublishierRepository _publishierRepository;
        private readonly IBookPublishValidator _bookPublishValidator;
        private readonly IPublishBookBll _publishBookBll;

        public BookBll(IBookRepository repository,
                       IPublishierRepository publishierRepository,
                       IBookPublishValidator bookPublishValidator,
                       IPublishBookBll publishBookBll)
        {
            _repository = repository;
            _publishierRepository = publishierRepository;
            _bookPublishValidator = bookPublishValidator;
            _publishBookBll = publishBookBll;
        }

        public BookResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id)
                .AsNoTracking()
                .Include(x => x.BookCategories)
                .SingleOrDefault() ?? throw new EntityNotFoundException($"Book ({id})");

            var response = Mapper.Map<BookResponseDTO>(entity);

            return response;
        }

        public IList<BookResponseDTO> GetAll()
        {
            var entities = _repository.GetAll()
                .AsNoTracking()
                .Include(x => x.BookCategories)
                .ToList();

            var response = Mapper.Map<List<BookResponseDTO>>(entities);

            return response;
        }

        public Guid Insert(BookRequestDTO request)
        {
            var entity = Mapper.Map<BookEntity>(request);

            _repository.Insert(entity);

            return entity.Id;
        }

        public void Update(Guid id, BookRequestDTO request)
        {
            var entity = _repository.Get(id)
                .SingleOrDefault() ?? throw new EntityNotFoundException($"Book ({id})");

            Mapper.Map(request, entity);

            _repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id)
                .SingleOrDefault() ?? throw new EntityNotFoundException($"Book ({id})");

            _repository.Delete(entity);
        }

        public void PublishBook(Guid? id, PublishBookRequestDTO publishBookRequest)
        {
            var bookAsync = _repository.Get(id.GetValueOrDefault())
                .Include(x => x.AuthorsBook)
                .ThenInclude(x => x.Author)
                .ThenInclude(x => x.Publishier)
                .SingleOrDefaultAsync();

            var publisherAsync = _publishierRepository.Get(publishBookRequest.PublishierId.GetValueOrDefault())
                .SingleOrDefaultAsync();

            var book = bookAsync.Result ?? throw new EntityNotFoundException($"Book ({id})");
            var publisher = publisherAsync.Result ?? throw new EntityNotFoundException($"Publishier ({publishBookRequest.PublishierId})");

            _publishBookBll.Publish(book, publisher);
        }

        public void UnPublish(Guid? id)
        {
            var book = _repository.Get(id.GetValueOrDefault())
                .Include(x => x.Publishier)
                .FirstOrDefault() ?? throw new EntityNotFoundException($"Book ({id})");

            book.UnPublish();

            _repository.Update(book);
        }
    }
}
