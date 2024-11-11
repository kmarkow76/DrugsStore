namespace Domain.Entities
{
    /// <summary>
    /// Единиуа товара 
    /// </summary>
    public class DrugItem : BaseEntities
    {
        public DrugItem(Guid drugId, Drug drug, DrugsStore drugStore, Guid drugStoreId, int count, decimal cost)
        {
            DrugID = drugId;
            Drug = drug;
            DrugStore = drugStore;
            DrugStoreId = drugStoreId;
            Count = count;
            Cost = cost;
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
        public int Count { get; private set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Cost { get; private set; }
        // Навигационные свойства
        public Drug Drug { get; private set; }
        public DrugsStore DrugStore { get; private set; }
    }
}