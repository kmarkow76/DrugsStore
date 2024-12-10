using Domain.Entities;
using Infrastruction.Dal.Configuration;
using Infrastruction.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;

namespace Infrastruction.Dal;
/// <summary>
/// Контекст базы данных
/// </summary>
public class DrugsBotDbContext : DbContext
{
    private readonly DatabaseSettings _options;

    /// <summary>
    /// Конструктор
    /// </summary>
    public DrugsBotDbContext(IOptions<DatabaseSettings> options)
    {
        _options = options.Value;
    }
    /// <summary>
    /// Сущность профиля
    /// </summary>
    public DbSet<Profile> UserProfiles { get; init; }
    
    /// <summary>
    /// Сущность лекарства
    /// </summary>
    public DbSet<Drug> Drugs { get; init; }
    
    /// <summary>
    /// Сущность аптеки
    /// </summary>
    public DbSet<DrugsStore> DrugStores { get; init; }
    
    /// <summary>
    /// Сущность страны
    /// </summary>
    public DbSet<Country> Countries { get; init; }
    
    /// <summary>
    /// Служебная таблица связи лекарства и магазина
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; init; }
    
    /// <summary>
    /// Сущность любимого лекарства 
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrugs { get; init; }
    /// <summary>
    /// OnConfiguring
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_options.ConnectionString, (options) =>
        {
            options.CommandTimeout(_options.CommandTimeout);
        });
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
    }
}