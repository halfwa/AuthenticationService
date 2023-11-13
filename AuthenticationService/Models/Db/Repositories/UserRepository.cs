using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.Models.Db.Contexts;

namespace AuthenticationService.Models.Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthAppContext _context;
        public UserRepository(AuthAppContext context) => _context = context;

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll()
        {
           return _context.Users.ToList();
        }

        public User GetByLogin(string login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Login == login);

            return user;
        }

    }
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
        Task Add(User user);
    }
}
