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
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "11111122222qq",
                Login = "ivanov",
                Role = new Role()
                {
                    Id = 1,
                        Name = "Пользователь"
                }
            });     

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Максим",
                LastName = "Максимов",
                Email = "maksim@gmail.com",
                Password = "11",
                Login = "maxim",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Администратор"
                }
            });

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Антон",
                LastName = "Антонов",
                Email = "anton@gmail.com",
                Password = "111zzxc1",
                Login = "anton",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });
        }

        public IEnumerable<User> GetAll()
        {
           return _users;
        }

        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }

    }
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
