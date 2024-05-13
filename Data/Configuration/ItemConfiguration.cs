using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusModuleTemplate.Entities;

namespace NexusModuleTemplate.Data.Configuration;

internal class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasIndex(i => i.Name)
            .IsUnique();
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(i => i.Price, p =>
        {
            p.Property(pp => pp.Value)
                .IsRequired();
            p.Property(pp => pp.Currency)
                .IsRequired();
        });
    }
}
