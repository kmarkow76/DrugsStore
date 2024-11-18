namespace Domain.Entities
{
    /// <summary>
    /// Страна производитель
    /// </summary>
    public class Country : BaseEntities<Country>
    {
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// </summary>
        /// <param name="name">Название страны.</param>
        /// <param name="code">Код страны.</param>
        public Country(string name, string code)
        {
            Name = name;
            Code = code;
        }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Код страны
        /// </summary>
        public string Code { get; private set; }
        
        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
    }
}