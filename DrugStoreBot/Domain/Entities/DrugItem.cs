using Domain.DomainEvents;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Единиуа товара 
    /// </summary>
    public class DrugItem : BaseEntities<DrugItem>
    {
        public DrugItem(Guid drugId, Drug drug, DrugsStore drugStore, Guid drugStoreId, double count, decimal cost)
        {
            DrugID = drugId;
            Drug = drug;
            DrugStore = drugStore;
            DrugStoreId = drugStoreId;
            Count = count;
            Cost = cost;
            
            ValidateEntity(new DrugItemValidator());
        }

        /// <summary>
        /// ID лекарства
        /// </summary>
        public Guid DrugID { get;private set; }
        /// <summary>
        /// ID магазина
        /// </summary>
        public Guid DrugStoreId { get;private set; }
        /// <summary>
        /// Количество
        /// </summary>
        public double Count { get; private set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Cost { get; private set; }
        // Навигационные свойства
        public Drug Drug { get; private set; }
        public DrugsStore DrugStore { get; private set; }
        /// <summary>
        /// Обновить количество препарата на складе.
        /// </summary>
        /// <param name="count"></param>
        public void UpdateDrugCount(double count)
        {
            var oldCount = Count; 
            Count = count;
            ValidateEntity(new DrugItemValidator());

            AddDomainEvent(new DrugItemUpdatedEvent(Id, oldCount, count));
        }
        
    }
}