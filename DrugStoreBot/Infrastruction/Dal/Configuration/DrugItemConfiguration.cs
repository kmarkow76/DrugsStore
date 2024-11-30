using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruction.Dal.Configuration;

public class DrugItemConfiguration: IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));

        builder.HasKey(di => di.Id);

        builder.Property(di => di.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(di => di.Count)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(di => di.DrugId)
            .IsRequired();

        builder.Property(di => di.DrugStoreId)
            .IsRequired();

        builder.HasOne(di => di.DrugStore)
            .WithMany(ds => ds.DrugItems)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(di => di.Drug)
            .WithMany()
            .HasForeignKey(di => di.DrugId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}