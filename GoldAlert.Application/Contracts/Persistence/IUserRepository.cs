using GoldAlert.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetByMobileAsync(string mobile);
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
    }
}
