using Library.Bll.Interfaces;
using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/book-category")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryEnumBll _bookCategoryBll;

        public BookCategoryController(IBookCategoryEnumBll BookCategoryBll)
        {
            _bookCategoryBll = BookCategoryBll;
        }

        [HttpGet("values/{id}")]
        public IActionResult Get([FromRoute]BookCategoryEnum enumValue)
        {
            BookCategoryResponseDTO response = _bookCategoryBll.Get(enumValue);

            return Ok(response);
        }

        [HttpGet("values")]
        public IActionResult GetAll()
        {
            var response = _bookCategoryBll.GetAll();
            return Ok(response);
        }
    }
}