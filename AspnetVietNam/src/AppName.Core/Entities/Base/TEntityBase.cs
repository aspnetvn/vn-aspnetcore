namespace AppName.Core.Entities.Base
{
    public interface TEntityBase<Tkey>
    {
        /// <summary>
        /// The Primary key of Entity
        /// </summary>
        Tkey Id { get; }
    }
}
