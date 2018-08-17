using AutoMapper;
using Library.Bll.Exceptions;
using Library.Bll.Publisher.Interfaces;
using Library.Domain.DTO.Publishier;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Bll.Publisher
{
    public class PublisherBll : IPublishierBll
    {
        private readonly IPublishierRepository _repository;

        public PublisherBll(IPublishierRepository repository)
        { _repository = repository; }

        public PublishierResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id)
                .AsNoTracking()
                .SingleOrDefault() ?? throw new EntityNotFoundException($"Publishier ({id})");

            var response = Mapper.Map<PublishierResponseDTO>(entity);

            return response;
        }

        public IList<PublishierResponseDTO> GetAll()
        {
            var entities = _repository.GetAll()
                .ToList();

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
            var entity = _repository.Get(id)
                .SingleOrDefault() ?? throw new EntityNotFoundException($"Publishier ({id})");

            Mapper.Map(request, entity);

            _repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id)
                .SingleOrDefault() ?? throw new EntityNotFoundException($"Publishier ({id})");

            _repository.Delete(entity);
        }
    }
}
