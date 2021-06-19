using System.Collections.Generic;
using System.Linq;
using qrweb.businesslogic.Entities;
using qrweb.models;

namespace qrweb.Extensions
{
    public static class UserEntityExtensions
    {
        public static UserListItemViewModel ToListItem(this UserEntity userEntity)
        {
            return new UserListItemViewModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name
            };
        }

        public static IEnumerable<UserListItemViewModel> ToListItems(this IEnumerable<UserEntity> userEntity)
        {
            return userEntity.Select(ToListItem);
        }

        public static UserDetailsViewModel ToDetails(this UserEntity userEntity)
        {
            return new UserDetailsViewModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                B64QrCodeString = userEntity.B64QrCodeString
            };
        }
    }
}
