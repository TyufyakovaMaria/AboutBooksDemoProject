using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AboutBooksDemoProject.DataAccess.Entities
{
    public class CategoryEntity : BaseEntity
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Список книг, относящихся к данной категории
        /// </summary>
        public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
    }

    /// <summary>
    /// Конфигурация сущности категории (класс должен быть в отдельном файле)
    /// </summary>
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(e => e.Id)
                   .HasName("category_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnName("updated_at");

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("name");
        }
    }
}
