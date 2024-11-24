using Domain.Entities;
using Domain.ValueObject;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.UpdateDrugStoreCommand;

/// <summary>
/// Обновление DrugStore
/// </summary>
/// <param name="DrugNetwork">Аптечная сеть.</param>
/// <param name="Number">Номер аптеки.</param>
/// <param name="Address">Адрес.</param>
/// <param name="PhoneNumber">Номер телефона.</param>
public record UpdateDrugStoreCommand(Guid DrugStoreId,string DrugNetwork, int Number, Address Address, string PhoneNumber) : IRequest<DrugsStore>;