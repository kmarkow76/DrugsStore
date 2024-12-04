using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruction.Dal.Configuration;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugsStore>
{
    public void Configure(EntityTypeBuilder<DrugsStore> builder)
    {
        builder.ToTable(nameof(DrugsStore));
        
        builder.HasKey(ds => ds.Id);

        builder.HasIndex(ds => new { ds.DrugNetwork, ds.Number })
            .IsUnique();

        builder.Property(ds => ds.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ds => ds.Number)
            .IsRequired()
            .HasDefaultValue(0);

        builder.OwnsOne(ds => ds.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            addressBuilder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            addressBuilder.Property(a => a.House)
                .IsRequired()
                .HasMaxLength(10);

            addressBuilder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("char(6)");
        });
        
        builder.OwnsOne(ds => ds.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("char(2)"); 
        });
        
        builder.Property(ds => ds.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        
        builder.HasMany(ds => ds.DrugItems)
            .WithOne(di => di.DrugStore)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
     
    }
}