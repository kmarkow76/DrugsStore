using Domain.ValueObject;

namespace Domain.Entities
{
    /// <summary>
    /// Магазин лекарств
    /// </summary>
    class DrugsStore : BaseEntities
    {
        /// <summary>
        /// Сеть лекарств
        /// </summary>
        public string DrugNetwork {  get; set; }
        /// <summary>
        /// Число
        /// </summary>
        public int Number {  get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string PhoneNumber { get; set; } 
    }
}