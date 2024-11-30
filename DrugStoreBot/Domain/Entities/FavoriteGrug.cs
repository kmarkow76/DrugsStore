namespace Domain.Entities;

public class FavoriteDrug : BaseEntities<FavoriteDrug>
{
    public FavoriteDrug()
    {
    }

    public FavoriteDrug(
            Guid profileId,
            Guid drugId,
            Profile profile,
            Drug drug,
            Guid? drugStoreId = null,
            DrugsStore? drugStore = null)
        {
            ProfileId = profileId;
            DrugId = drugId;
            DrugStoreId = drugStoreId;
            Profile = profile;
            Drug = drug;
            DrugStore = drugStore;
        }

        /// <summary>
        /// Идентификатор профиля.
        /// </summary>
        public Guid ProfileId { get; private set; }

        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }

        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid? DrugStoreId { get; private set; }

        // Навигационные свойства
        public Profile Profile { get; private set; }
        public Drug Drug { get; private set; }
        public DrugsStore? DrugStore { get; private set; }
        public void Update(
            Guid profileId,
            Guid drugId,
            Profile profile,
            Drug drug,
            Guid? drugStoreId = null,
            DrugsStore? drugStore = null)
        {
            ProfileId = profileId;
            DrugId = drugId;
            DrugStoreId = drugStoreId;
            Profile = profile;
            Drug = drug;
            DrugStore = drugStore;
        }
}