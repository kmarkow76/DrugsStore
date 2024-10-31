namespace Domain.Entities
{
    /// <summary>
    /// Страна производитель
    /// </summary>
    public class Country : BaseEntities
    {
        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код страны
        /// </summary>
        public string Code { get; set; }
    }
}