using Library.Bll.Author.Interfaces;
using Library.Domain.DTO.Author;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers.Book
{
    [Route("api/[controller]")]
    public class AuthorController : ApiController
    {
        private readonly IAuthorBll _authorBll;

        public AuthorController(IAuthorBll authorBll)
        {
            _authorBll = authorBll;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid? id)
        {
            AuthorResponseDTO response = _authorBll.Get(id.GetValueOrDefault());

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _authorBll.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Insert(AuthorRequestDTO request)
        {
            var id = _authorBll.Insert(request);

            return CreatedAtAction(nameof(Insert), new { id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid? id, AuthorRequestDTO request)
        {
            _authorBll.Update(id.GetValueOrDefault(), request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]Guid? id)
        {
            _authorBll.Delete(id.GetValueOrDefault());

            return NoContent();
        }
    }
}