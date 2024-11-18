using Domain.Interface;

namespace Domain.DomainEvents;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed class DrugItemUpdatedEvent : IDomainEvent
{
    public Guid DrugItemId { get; }
    public double OldCount { get; }
    public double NewCount { get; }

    public DrugItemUpdatedEvent(Guid drugItemId, double oldCount, double newCount)
    {
        DrugItemId = drugItemId;
        OldCount = oldCount;
        NewCount = newCount;
    }
}