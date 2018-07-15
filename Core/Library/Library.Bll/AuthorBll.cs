using AutoMapper;
using Library.Bll.Exceptions;
using Library.Bll.Interfaces;
using Library.Domain.DTO.Author;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Library.Bll
{
    public class AuthorBll : IAuthorBll
    {
        private readonly IAuthorRepository _repository;

        public AuthorBll(IAuthorRepository repository)
        { _repository = repository; }

        public AuthorResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException();

            var response = Mapper.Map<AuthorResponseDTO>(entity);

            return response;
        }

        public IList<AuthorResponseDTO> GetAll()
        {
            return Mapper.Map<List<AuthorResponseDTO>>(_repository.GetAll());
        }

        public Guid Insert(AuthorRequestDTO request)
        {
            var entity = Mapper.Map<AuthorEntity>(request);

            _repository.Insert(entity);

            return entity.Id;
        }

        public void Update(Guid id, AuthorRequestDTO request)
        {
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException();

            entity = Mapper.Map<AuthorEntity>(request);
            entity.Id = id;

            _repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id) ?? throw new EntityNotFoundException();

            _repository.Delete(entity);
        }
    }
}
