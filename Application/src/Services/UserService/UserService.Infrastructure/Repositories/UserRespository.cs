using UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserService.Domain;

namespace UserService.Infrastructure.Repositories
{
    public class UserRespository : IUserRepository
    {

        private readonly List<User> _events = new List<User>();
        private readonly UserDBContext _dbContext;

        public UserRespository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User user)
        {
            var result = _dbContext.USERS.Add(user);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public Task<int> DeleteAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.USERS.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _dbContext.USERS.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<int> UpdateAsync(UserProfile userProfile)
        {

            var profile = await _dbContext.UserProfile.FirstOrDefaultAsync(x => x.UserId == userProfile.UserId);
            if (profile != null)
            {
                profile.Address = userProfile.Address;
                profile.ContactNumber = userProfile.ContactNumber;
                _dbContext.UserProfile.Update(profile);
            }
            else
            {
                _dbContext.UserProfile.Add(userProfile);
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateLoginStatusAsync(User user)
        {
            _dbContext.USERS.Update(user);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
