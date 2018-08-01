using AutoMapper;
using Library.Bll.Exceptions;
using Library.Bll.Interfaces;
using Library.Domain.DTO.Author;
using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Bll
{
    public class BookBll : IBookBll
    {
        private readonly IBookRepository _repository;

        public BookBll(IBookRepository repository)
        { _repository = repository; }

        public BookResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id, true) ?? throw new EntityNotFoundException();

            var response = Mapper.Map<BookResponseDTO>(entity);

            response.Authors = Mapper.Map<List<AuthorResponseDTO>>(entity.AuthorsBook.Select(x => x.Author));

            return response;
        }

        public IList<BookResponseDTO> GetAll()
        {
            var entities = _repository.GetAll(true);

            var response = Mapper.Map<List<BookResponseDTO>>(entities);

            foreach (var book in response)
            {
                book.Authors = Mapper.Map<List<AuthorResponseDTO>>(
                    entities.FirstOrDefault(x => x.Id == book.Id)?.
                        AuthorsBook.Select(x => x.Author));
            }

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
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException();

            Mapper.Map(request, entity);

            _repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException();

            _repository.Delete(entity);
        }
    }
}
