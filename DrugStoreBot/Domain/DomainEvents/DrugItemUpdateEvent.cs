using Domain.Interface;

namespace Domain.DomainEvents;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed class DrugItemUpdatedEvent : IDomainEvent
{
    internal DrugItemUpdatedEvent(){}
}