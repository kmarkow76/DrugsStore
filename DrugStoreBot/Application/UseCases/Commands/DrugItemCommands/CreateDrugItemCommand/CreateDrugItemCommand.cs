using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateDrugItemCommand;

/// <summary>
/// Создание DrugItem
/// </summary>
/// <param name="DrugId">Идентификатор Drug.</param>
/// <param name="Drug">Drug.</param>
/// <param name="DrugStoreId">Идентификатор DrugStore</param>
/// <param name="DrugStore">DrugStore.</param>
/// <param name="Cost">Цена.</param>
/// <param name="Count">Количество.</param>
public record CreateDrugItemCommand(Guid DrugId, Drug Drug, DrugsStore DrugStore, Guid DrugStoreId, double Count, decimal Cost) : IRequest<DrugItem>;