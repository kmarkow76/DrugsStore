namespace Domain.Entities
{
    internal class DrugItem : BaseEntities
    {
        public Guid DrugID { get; set; }
        public Guid DrugStoreId { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    }
}