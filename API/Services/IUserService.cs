using AQUI_ESTOY.Models;
namespace AQUI_ESTOY.Services
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel> GetUserAsync(int userId);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
    }
}
