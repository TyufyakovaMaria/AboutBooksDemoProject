using AboutBooksDemoProject.DataAccess.Entities;
using AboutBooksDemoProject.DTOs;
using AutoMapper;

namespace AboutBooksDemoProject.DataAccess
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, BookDto>();
            CreateMap<AuthorEntity, AuthorDto>();
            CreateMap<CategoryEntity, CategoryDto>();
        }
    }
}
