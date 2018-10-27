using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class UserModule
    {
        private readonly UserRepository _userRepository;

        public UserModule(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserRequest AddUser(UserRequest userRequest)
        {
            var user = new User
            {
                Username = userRequest.Username,
                UserPass =  userRequest.UserPass,
                Role = userRequest.Role
            };

            _userRepository.SaveUser(user);

            return userRequest;
        }
    }
}
