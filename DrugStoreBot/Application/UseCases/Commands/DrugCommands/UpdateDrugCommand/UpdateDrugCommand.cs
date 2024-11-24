using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.UpdateDrugCommand;

/// <summary>
/// Обновление Drug
/// </summary>
/// <param name="DrugId">Идентификатор Drug.</param>
/// <param name="Name">Название.</param>
/// <param name="Manufacturer">Производитель.</param>
/// <param name="CountryCodeId">Код страны - страна изготовитель.</param>
/// <param name="Country">Навигационное поле для Country.</param>
public record UpdateDrugCommand(Guid DrugId, string Name, string Manufacturer, string CountryCodeId, Country Country) : IRequest<Drug>;