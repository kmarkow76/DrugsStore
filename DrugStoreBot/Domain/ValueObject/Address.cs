namespace Domain.ValueObject
{
    /// <summary>
    /// Адрес магазина
    /// </summary>
    public class Address
    {
        public Address(string street, string city, string house, string postalCode, string country)
        {
            Street = street;
            City = city;
            House = house;
            PostalCode = postalCode;
            Country = country;
        }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Дом
        /// </summary>
        public string House{ get; set; }
        public string PostalCode { get; set; }
        /// <summary>
        /// Код страны (ISO)
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, представляющая адрес.</returns>
        public override string ToString()
        {
            return $"{City}, {Street}, {House}, {PostalCode}";
        }
    }
}