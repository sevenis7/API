namespace AspApplication.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);

        Task Delete(T entity);

        Task Update(T entity);

        Task<IEnumerable<T>> GetAll();

    }
}
