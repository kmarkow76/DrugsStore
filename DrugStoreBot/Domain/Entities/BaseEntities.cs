namespace Domain.Entities
{
    /// <summary>
    /// Основыные поля
    /// </summary>
    public abstract class BaseEntities
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; protected set; }

        public BaseEntities()
        {
            Id = Guid.NewGuid();
        }
        
        public override bool Equals(object other)
        {
            if (other is BaseEntities otherEntity)
            {
               return Id == otherEntity.Id;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool AreEqual(BaseEntities entity1, BaseEntities entity2)
        {
            if (ReferenceEquals(entity1, entity2)) return true;
            if (entity1 is null || entity2 is null) return false;
            return Equals(entity1, entity2);
        }
        
        public bool AreNotEqual(BaseEntities entity1, BaseEntities entity2)
        {
            return !(entity1 == entity2);
        }
    }
}