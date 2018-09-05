using Library.Bll.User.Interfaces;
using Library.Domain.DTO.User.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginBll _loginBll;

        public LoginController(ILoginBll loginBll)
        {
            _loginBll = loginBll;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDTO userRequest)
        {
            var response = _loginBll.Authenticate(userRequest.Login, userRequest.Password);

            return Ok(response);
        }
    }
}
