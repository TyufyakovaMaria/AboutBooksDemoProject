using AboutBooksDemoProject.DataAccess;
using AboutBooksDemoProject.DTOs;
using AboutBooksDemoProject.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AboutBooksDemoProject.Services
{
    public class BookService : IBookService
    {
        private readonly AboutBooksContext _context;
        private readonly IMapper _mapper;

        public BookService(AboutBooksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение книг со всеми связанными сущностями и пагинацией
        /// </summary>
        /// <param name="skip">С какой записи начать получение</param>
        /// <param name="take">Сколько записей получить</param>
        /// <returns></returns>
        public async Task<IEnumerable<BookDto>> GetBooksWithAuthorsAndCategoriesAsync(int skip = 0, int take = 10)
        {
            var books = await _context.Books
                                      .AsNoTracking()
                                      .Include(b => b.Author)
                                      .Include(b => b.Categories)
                                      .Skip(skip * take)
                                      .Take(take)
                                      .ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        /// <summary>
        /// Получить книгу со связанными сущностями по идентификатору 
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns></returns>
        public async Task<BookDto> GetBookByIdAsync(uint id)
        {
            var book = await _context.Books
                                     .AsNoTracking()
                                     .Include(b => b.Author) // лучше конкретные поля
                                     .Include(b => b.Categories) //лучше конретные поля
                                     .FirstOrDefaultAsync(b => b.Id == id);

            return book == null ? new() : _mapper.Map<BookDto>(book);
        }
    }
}
