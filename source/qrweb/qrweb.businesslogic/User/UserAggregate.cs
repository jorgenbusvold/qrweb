using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qrweb.businesslogic.Entities;
using qrweb.businesslogic.Repositories;

namespace qrweb.businesslogic.User
{
    public interface IUser
    {
        Task Create(UserEntity user);
    }

    public class UserAggregate : IUser
    {
        private readonly IUserRepository _userRepository;

        public UserAggregate(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(UserEntity user)
        {
            await _userRepository.Insert(user);
        }
    }
}
