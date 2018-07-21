using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController()
        {
        }

        [HttpGet]
        public IList<BookEntity> GetBooks()
        {
            return null;
        }
    }
}