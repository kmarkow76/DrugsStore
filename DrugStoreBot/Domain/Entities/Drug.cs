using System.ComponentModel.DataAnnotations;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Леекарственный препарат
    /// </summary>
    public class Drug:BaseEntities<Drug>
    {
        public Drug()
        {
        }

        public Drug(string name, string manufacturer, string countryCodeId, Country country)
        {
            Name = name;
            Manufacturer = manufacturer;
            CountryCodeId = countryCodeId;
            Country = country;

            ValidateEntity(new DrugValidator());
        }

        /// <summary>
        /// Название лекарства
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; }
        
        /// <summary>
        /// Код страны 
        /// </summary>
        public string CountryCodeId { get; set; }
        
        // Навигационное свойство для связи с объектом Country
        public Country Country { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();

    }
}