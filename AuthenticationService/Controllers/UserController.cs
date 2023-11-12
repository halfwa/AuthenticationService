using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        public UserController(ILogger logger)
        {
            _logger = logger;
             
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
    }
}
