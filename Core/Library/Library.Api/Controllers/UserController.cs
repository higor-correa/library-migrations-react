using Library.Bll.User.Interfaces;
using Library.Domain.DTO.User;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly IUserBll _userBll;

        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid? id)
        {
            UserResponseDTO response = _userBll.Get(id.GetValueOrDefault());

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _userBll.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Insert(UserRequestDTO request)
        {
            var id = _userBll.Insert(request);

            return CreatedAtAction(nameof(Insert), new { id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid? id, UserRequestDTO request)
        {
            _userBll.Update(id.GetValueOrDefault(), request);

            return NoContent();
        }

        [HttpPost("{id}/disable")]
        public IActionResult Disable([FromRoute]Guid? id)
        {
            _userBll.Disable(id.GetValueOrDefault());

            return NoContent();
        }
    }
}
