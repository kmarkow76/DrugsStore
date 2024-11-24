using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateDrugCommand;
/// <summary>
/// Создание Drug
/// </summary>
/// <param name="Name">Название.</param>
/// <param name="Manufacturer">Производитель.</param>
/// <param name="CountryCodeId">Код страны - страна изготовитель.</param>
/// <param name="Country">Навигационное поле для Country.</param>
public record CreateDrugCommand(string Name, string Manufacturer, string CountryCodeId, Country Country) : IRequest<Drug>;