namespace Domain.Entities
{
    /// <summary>
    /// Леекарственный препарат
    /// </summary>
    internal class Drug:BaseEntities
    {
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
        
    }
}