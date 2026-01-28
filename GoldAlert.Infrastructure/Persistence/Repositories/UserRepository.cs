using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoldPingDbContext _context;

        public UserRepository(GoldPingDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByMobileAsync(string mobile)
            => await _context.Users.FirstOrDefaultAsync(x => x.Mobile == mobile);

        public async Task<User?> GetByIdAsync(Guid id)
            => await _context.Users.FindAsync(id);

        public async Task AddAsync(User user)
            => await _context.Users.AddAsync(user);
    }
}
