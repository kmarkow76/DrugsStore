namespace Domain.Entities
{
    /// <summary>
    /// Леекарственный препарат
    /// </summary>
    internal class Drug:BaseEntities
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string CountryCodeId { get; set; }
        
    }
}