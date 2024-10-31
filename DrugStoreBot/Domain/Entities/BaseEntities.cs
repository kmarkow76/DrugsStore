namespace Domain.Entities
{
    /// <summary>
    /// TODO: Везеде комментарии, где public 
    /// </summary>
    public abstract class BaseEntities
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; protected set; }

        public override bool Equals(object other)
        {
            // TODO: переопределить так, чтобы сравнение было по ID
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        
        //TODO: Переоределить операторы == и !=
        
        //Разобраться с Dookerom и навигацией PassGress последняяяяяя версия 
    }
}