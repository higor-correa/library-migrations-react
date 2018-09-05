using Library.Domain.DTO.User;
using System;
using System.Collections.Generic;

namespace Library.Bll.User.Interfaces
{
    public interface IUserBll
    {
        UserResponseDTO Get(Guid? id);
        IList<UserResponseDTO> GetAll();
        Guid Insert(UserRequestDTO request);
        void Update(Guid? id, UserRequestDTO request);
        void Disable(Guid? id);
    }
}
