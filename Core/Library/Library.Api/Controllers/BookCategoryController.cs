using Library.Bll.BookCategory.Types.Interface;
using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/book-category")]
    public class BookCategoryController : ApiController
    {
        private readonly IBookCategoryTypesBll _bookCategoryBll;

        public BookCategoryController(IBookCategoryTypesBll BookCategoryBll)
        {
            _bookCategoryBll = BookCategoryBll;
        }

        [HttpGet("type/{id}")]
        public IActionResult Get([FromRoute]BookCategoryEnum enumValue)
        {
            BookCategoryResponseDTO response = _bookCategoryBll.Get(enumValue);

            return Ok(response);
        }

        [HttpGet("type")]
        public IActionResult GetAll()
        {
            var response = _bookCategoryBll.GetAll();
            return Ok(response);
        }
    }
}