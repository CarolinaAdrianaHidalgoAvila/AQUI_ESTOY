using AQUI_ESTOY.Data.Entities;
namespace AQUI_ESTOY.Data.Repository
{
    public interface IUserRepository
    {
        void CreateUser(UserEntity user);

        Task<IEnumerable<UserEntity>> GetAllUsersAsync();

        Task<UserEntity> GetUserAsync(int userId);

        Task<bool> SaveChangesAsync();
    }
}
