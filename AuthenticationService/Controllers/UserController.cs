using AuthenticationService.Models.Db;
using AuthenticationService.Models.Db.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserController(
            ILogger logger,
            IMapper mapper,
            IUserRepository userRepository
            )
        {
            _logger = logger;
            _mapper = mapper; 
            _userRepository = userRepository;
             
            logger.WriteEvent("Сообщение о событии в программе");
            logger.WriteError("Сообщение об ошибки в программе");
        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrew",
                LastName = "Tate",
                Email = "kobra@mail.ru",
                Password = "11112222",
                Login = "Kobratate"
            };
        }

        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Elon",
                LastName = "Mask",
                Email = "elon@gmail.com",
                Password = "11112222",
                Login = "ElonMask"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }
}
