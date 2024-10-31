using Domain.ValueObject;

namespace Domain.Entities
{
    class DrugsStore : BaseEntities
    {
        public string DrugNetwork {  get; set; }
        public int Number {  get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; } 
    }
}