namespace Domain.ValueObject
{
    public class Address
    {
        public Address(string street, string city, string home)
        {
            Street = street;
            City = city;
            Home = home;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string Home { get; set; }
    }
}