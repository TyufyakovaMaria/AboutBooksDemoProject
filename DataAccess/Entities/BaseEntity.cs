using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AboutBooksDemoProject.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Дата и время создания в UnixTimeStamp
        /// </summary>
        public long CreatedAt { get; set; }

        /// <summary>
        /// Дата и время последнего изменения данных сущности в UnixTimeStamp
        /// </summary>
        public long UpdatedAt { get; set; }

        protected BaseEntity()
        {
            var currentTime = DateTime.UtcNow;
            CreatedAt = new DateTimeOffset(currentTime).ToUnixTimeSeconds();
            UpdatedAt = CreatedAt;
        }

        /// <summary>
        /// Обновляет время последних изменений в сущности
        /// </summary>
        public void UpdateModifiedTimestamp()
        {
            UpdatedAt = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }

    /// <summary>
    /// Конфигурация базовой сущности (класс должен быть в отдельном файле)
    /// </summary>
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnName("updated_at");
        }
    }
}
