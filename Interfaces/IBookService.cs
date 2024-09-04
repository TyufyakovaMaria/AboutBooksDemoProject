using AboutBooksDemoProject.DataAccess.Entities;
using AboutBooksDemoProject.DTOs;

namespace AboutBooksDemoProject.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksWithAuthorsAndCategoriesAsync(int skip = 0, int take = 10);
    }
}
