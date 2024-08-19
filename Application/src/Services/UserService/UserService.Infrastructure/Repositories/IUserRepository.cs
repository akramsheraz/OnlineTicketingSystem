using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Infrastructure.Repositories
{
    public interface IUserRepository
    {        
        Task<User> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
        Task<int> UpdateAsync(UserProfile user);
        Task<int> DeleteAsync(string userId);
        Task<int> UpdateLoginStatusAsync(User user);
        Task<User> GetByIdAsync(int userId);
    }
}
