using Libary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libary.Data.Map
{
    public class LibaryMap : IEntityTypeConfiguration<LibaryModel>
    {
        public void Configure(EntityTypeBuilder<LibaryModel> builder)
        {
            builder.HasKey(libary => libary.Id);
            builder.Property(libary => libary.Name).IsRequired().HasMaxLength(255);
            builder.Property(libary => libary.Author).IsRequired().HasMaxLength(255);
            builder.Property(libary => libary.Description).HasMaxLength(2000);
            builder.Property(libary => libary.ImageUrl).HasMaxLength(2000);
        }
    }
}
