using System;
using System.Collections.Generic;
using Library.Domain.DTO.Publishier;

namespace Library.Bll.Interfaces
{
    public interface IPublishierBll
    {
        IList<PublishierResponseDTO> GetAll();
        PublishierResponseDTO Get(Guid guid);
        Guid Insert(PublishierRequestDTO request);
        void Update(Guid guid, PublishierRequestDTO request);
        void Delete(Guid guid);
    }
}
