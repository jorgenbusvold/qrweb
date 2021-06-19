using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qrweb.businesslogic.Entities;
using qrweb.businesslogic.Repositories;

namespace qrweb.data
{
    public class UserRepositoryMock : IUserRepository
    {
        private List<UserEntity> _userEntities = new List<UserEntity>();

        public UserRepositoryMock()
        {
            _userEntities.Add(new UserEntity { Id = Guid.NewGuid(), Name = "Terry Tester" });
            _userEntities.Add(new UserEntity { Id = Guid.NewGuid(), Name = "Harry Hacker" });
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await Task.FromResult(_userEntities);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await Task.FromResult(_userEntities.FirstOrDefault(x => x.Id == id));
        }

        public Task Insert(UserEntity user)
        {
            _userEntities.Add(user);
            return Task.CompletedTask;
        }
    }
}
