using Library.Bll.Interfaces;
using Library.Domain.DTO.Book;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBll _bookBll;

        public BookController(IBookBll BookBll)
        {
            _bookBll = BookBll;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid? id)
        {
            BookResponseDTO response = _bookBll.Get(id.GetValueOrDefault());

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _bookBll.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Insert(BookRequestDTO request)
        {
            var id = _bookBll.Insert(request);

            return CreatedAtAction(nameof(Insert), new { id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid? id, BookRequestDTO request)
        {
            _bookBll.Update(id.GetValueOrDefault(), request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]Guid? id)
        {
            _bookBll.Delete(id.GetValueOrDefault());

            return NoContent();
        }

        [HttpPost("{id}/publish")]
        public IActionResult PublishBook([FromRoute] Guid? id, [FromBody] PublishBookRequestDTO request)
        {
            _bookBll.PublishBook(id, request);

            return NoContent();
        }
    }
}