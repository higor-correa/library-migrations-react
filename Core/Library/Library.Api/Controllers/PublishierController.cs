using Library.Bll.Interfaces;
using Library.Domain.DTO.Publishier;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishierController : ControllerBase
    {
        private readonly IPublishierBll _publishierBll;

        public PublishierController(IPublishierBll PublishierBll)
        {
            _publishierBll = PublishierBll;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid? id)
        {
            PublishierResponseDTO response = _publishierBll.Get(id.GetValueOrDefault());

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _publishierBll.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Insert(PublishierRequestDTO request)
        {
            var id = _publishierBll.Insert(request);

            return CreatedAtAction(nameof(Insert), new { id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid? id, PublishierRequestDTO request)
        {
            _publishierBll.Update(id.GetValueOrDefault(), request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]Guid? id)
        {
            _publishierBll.Delete(id.GetValueOrDefault());

            return NoContent();
        }
    }
}