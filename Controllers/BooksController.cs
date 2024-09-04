using AboutBooksDemoProject.DTOs;
using AboutBooksDemoProject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AboutBooksDemoProject.Controllers
{
    //[Authorize] - если нужно
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Получить все книги со связанными сущностями
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<BookDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllBooksWithDetails(int skip = 0, int take = 10)
        {
            var books = await _bookService.GetBooksWithAuthorsAndCategoriesAsync(skip, take);
            if (!books.Any())
            {
                return NoContent();
            }

            return Ok(books);
        }
    }
}
