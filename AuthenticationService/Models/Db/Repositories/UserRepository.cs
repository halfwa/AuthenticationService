using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AuthenticationService.Models.Db.Contexts;

namespace AuthenticationService.Models.Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthAppContext _context;
        public UserRepository(
            AuthAppContext context
            )
        {
           _context = context;
        }
        public IEnumerable<User> GetAll()
        {
           var users = _context.Users.ToList();
           return users;
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

    }
}
