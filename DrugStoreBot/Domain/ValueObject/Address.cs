namespace Domain.ValueObject
{
    /// <summary>
    /// Адрес магазина
    /// </summary>
    public class Address
    {
        public Address(string street, string city, string home)
        {
            Street = street;
            City = city;
            Home = home;
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
        public string Home { get; set; }
    }
}