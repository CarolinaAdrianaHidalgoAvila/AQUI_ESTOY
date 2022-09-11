using AQUI_ESTOY.Data.Entities;
namespace AQUI_ESTOY.Data.Repository
{
    public interface IUserRepository
    {
        void CreateUser(UserEntity user);
        Task<bool> SaveChangesAsync();
    }
}
