using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
    public static class UserExtentions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
            };
        }
        public static User AsEntity(this UserDto userDto)
        {
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateOfBirth = userDto.DateOfBirth,
                Gender = userDto.Gender,
            };
        }
    }
}
