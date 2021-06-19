using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using qrweb.businesslogic.Entities;

namespace qrweb.businesslogic.Repositories
{
    public interface IReadOnlyUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Get(Guid id);
    }

    public interface IUserRepository: IReadOnlyUserRepository
    {
        Task Insert(UserEntity user);
    }
}
