namespace AppName.Core.Entities.Base
{
    public interface TEntityBase<Tkey>
    {
        Tkey Id { get; }
    }
}
