using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Library.Bll.Exceptions;
using Library.Bll.User.Interfaces;
using Library.Domain.DTO.User;
using Library.Domain.Entities;
using Library.Repository.Interfaces;

namespace Library.Bll.User
{
    public class UserBll : IUserBll
    {
        private IUserRepository _userRepository;

        public UserBll(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserResponseDTO Get(Guid? id)
        {
            var entity = _userRepository.Get(id.GetValueOrDefault())
                .SingleOrDefault() ?? throw new EntityNotFoundException($"User ({id})");

            return Mapper.Map<UserResponseDTO>(entity);
        }

        public IList<UserResponseDTO> GetAll()
        {
            var usuarios = _userRepository.GetAll().Where(x => x.Active).ToList();

            var response = Mapper.Map<List<UserResponseDTO>>(usuarios);

            return response;
        }

        public Guid Insert(UserRequestDTO request)
        {
            var entity = Mapper.Map<UserEntity>(request);

            _userRepository.Insert(entity);

            return entity.Id;
        }

        public void Update(Guid? id, UserRequestDTO request)
        {
            var entity = _userRepository.Get(id.GetValueOrDefault())
                .SingleOrDefault() ?? throw new EntityNotFoundException($"User ({id})");

            Mapper.Map(request, entity);

            _userRepository.Update(entity);
        }

        public void Disable(Guid? id)
        {
            var entity = _userRepository.Get(id.GetValueOrDefault())
                .SingleOrDefault() ?? throw new EntityNotFoundException($"User ({id})");

            entity.Disable();

            _userRepository.Update(entity);
        }
    }
}
