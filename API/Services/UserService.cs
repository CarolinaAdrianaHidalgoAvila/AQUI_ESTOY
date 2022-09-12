using AutoMapper;
using AQUI_ESTOY.Data.Entities;
using AQUI_ESTOY.Data.Repository;
using AQUI_ESTOY.Models;
namespace AQUI_ESTOY.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _userRepository.CreateUser(userEntity);
            var result = await _userRepository.SaveChangesAsync();
            if (result)
            {
                return _mapper.Map<UserModel>(userEntity);
            }
            throw new Exception("Database Error");
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var usersEntityList = await _userRepository.GetAllUsersAsync();
            var usersModelList = _mapper.Map<IEnumerable<UserModel>>(usersEntityList);
            return usersModelList;
        }

        public async Task<UserModel> GetUserAsync(int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            //if (user == null) Cuando se implementen errores**********
            //{
            //    throw new NotFoundElementException($"The player with id:{playerId} does not exists.");
            //}
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

    }


}
