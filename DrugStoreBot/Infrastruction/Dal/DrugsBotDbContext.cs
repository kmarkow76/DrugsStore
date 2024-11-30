using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastruction.Dal;
/// <summary>
/// Контекст базы данных
/// </summary>
public class DrugsBotDbContext : DbContext
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {
    }
    /// <summary>
    /// Пустой конструктор для EF
    /// </summary>
    public DrugsBotDbContext()
    {
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

        optionsBuilder.UseNpgsql(
            "User ID=postgres;Password=123;Host=localhost;Port=5432;Database=DrugsBot;");
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DrugsBotDbContext).Assembly);
    }
}