namespace DentistSite.Domain.Entities.Base
{
    public interface IHaveIdentity<T>
    {
        T Id { get; }
    }
}