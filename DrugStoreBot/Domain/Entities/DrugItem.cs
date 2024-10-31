namespace Domain.Entities
{
    /// <summary>
    /// Единиуа товара 
    /// </summary>
    public class DrugItem : BaseEntities
    {
        /// <summary>
        /// ID лекарства
        /// </summary>
        public Guid DrugID { get; set; }
        /// <summary>
        /// ID магазина
        /// </summary>
        public Guid DrugStoreId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Cost { get; set; }
    }
}