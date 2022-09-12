using AQUI_ESTOY.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AQUI_ESTOY.Data.Repository
{
    public class UserRepository: IUserRepository
    {
        private AquiEstoyDBContext _dbContext;
        public UserRepository(AquiEstoyDBContext AquiEstoy_DBContext)
        {
            _dbContext = AquiEstoy_DBContext;
        }


        public void CreateUser(UserEntity user)
        {
            _dbContext.Users.Add(user);
        }

        public async Task<UserEntity> GetUserAsync(int userId)
        {
            IQueryable<UserEntity> query = _dbContext.Users;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            IQueryable<UserEntity> query = _dbContext.Users;
            query = query.AsNoTracking();
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
