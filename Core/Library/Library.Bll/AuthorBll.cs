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
    public class AuthorBll : IAuthorBll
    {
        private readonly IAuthorRepository _repository;

        public AuthorBll(IAuthorRepository repository)
        { _repository = repository; }

        public AuthorResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id, true) ?? throw new EntityNotFoundException($"Author ({id})");

            var response = Mapper.Map<AuthorResponseDTO>(entity);

            response.Books = Mapper.Map<List<BookResponseDTO>>(entity.BooksAuthor.Select(x => x.Book));

            return response;
        }

        public IList<AuthorResponseDTO> GetAll()
        {
            var entities = _repository.GetAll();

            var response = Mapper.Map<List<AuthorResponseDTO>>(entities);

            return response;
        }

        public Guid Insert(AuthorRequestDTO request)
        {
            var entity = Mapper.Map<AuthorEntity>(request);

            _repository.Insert(entity);

            return entity.Id;
        }

        public void Update(Guid id, AuthorRequestDTO request)
        {
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException($"Author ({id})");

            Mapper.Map(request, entity);

            _repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException($"Author ({id})");

            _repository.Delete(entity);
        }
    }
}
