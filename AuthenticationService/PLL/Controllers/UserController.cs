using AuthenticationService.BLL.Models;
using AuthenticationService.DAL.Repositories;
using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.PLL;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ExceptionHandler]
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

        [Authorize(Roles = "Администратор")]
        [HttpGet]   
        [Route("viewmodel")]
        public UserViewModel GetUserViewModelAsync()
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

        [HttpGet]
        [Route("authenticate")]
        public async  Task<UserViewModel> Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) 
                || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Запрос не корректтен");
            }

            var user = _userRepository.GetByLogin(login);
            if (user is null)
            {
                throw new AuthenticationException("Пользователь не найден");
            }

            if (user.Password != password)
            {
                throw new AuthenticationException("Введеный пароль не корректен");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
