using Domain.ValueObject;

namespace Domain.Entities
{
    /// <summary>
    /// Магазин лекарств
    /// </summary>
    public class DrugsStore : BaseEntities
    {
        public DrugsStore(string drugNetwork, int number, Address address, string phoneNumber)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Сеть лекарств
        /// </summary>
        public string DrugNetwork {  get; private set; }
        /// <summary>
        /// Число
        /// </summary>
        public int Number {  get; private set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public Address Address { get; private set; }
        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string PhoneNumber { get; private set; } 
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    }
}