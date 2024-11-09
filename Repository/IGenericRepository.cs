public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> Create(T value);
    Task<bool> Update(T value);
    Task<bool> Delete(T value);
}