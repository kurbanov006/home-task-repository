public interface IDeveloperService
{
    Task<bool> Create(Developer developer);
    Task<bool> Update(Developer developer);
    Task<bool> Delete(int id);
    Task<IEnumerable<Developer>> GetAll();
    Task<Developer> GetById(int id);
}