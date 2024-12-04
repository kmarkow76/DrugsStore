using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruction.Dal.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100) // Длина от 2 до 100 символов
            .HasColumnType("nvarchar"); // Используемый тип данных

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(2) // Должен состоять из 2 символов
            .IsFixedLength() // Фиксированная длина строки
            .HasColumnType("char(2)"); // Двухсимвольный фиксированный тип
        
        builder.HasMany(x => x.Drugs)
            .WithOne(d => d.Country)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}