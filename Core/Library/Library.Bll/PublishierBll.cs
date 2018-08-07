using AutoMapper;
using Library.Bll.Exceptions;
using Library.Bll.Interfaces;
using Library.Domain.DTO.Book;
using Library.Domain.DTO.Publishier;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Bll
{
    public class PublishierBll : IPublishierBll
    {
        private readonly IPublishierRepository _repository;

        public PublishierBll(IPublishierRepository repository)
        { _repository = repository; }

        public PublishierResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id, true) ?? throw new EntityNotFoundException();

            var response = Mapper.Map<PublishierResponseDTO>(entity);

            return response;
        }

        public IList<PublishierResponseDTO> GetAll()
        {
            var entities = _repository.GetAll(true);

            var response = Mapper.Map<List<PublishierResponseDTO>>(entities);

            return response;
        }

        public Guid Insert(PublishierRequestDTO request)
        {
            var entity = Mapper.Map<PublishierEntity>(request);
            
            _repository.Insert(entity);

            return entity.Id;
        }

        public void Update(Guid id, PublishierRequestDTO request)
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
