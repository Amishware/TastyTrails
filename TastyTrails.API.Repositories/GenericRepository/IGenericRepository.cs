namespace TastyTrails.API.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
    }
}
