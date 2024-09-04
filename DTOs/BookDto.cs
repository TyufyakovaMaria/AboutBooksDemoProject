namespace AboutBooksDemoProject.DTOs
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long AuthorId { get; set; }
        public AuthorDto Author { get; set; }
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
