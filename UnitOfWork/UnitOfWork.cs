public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        Developers = new DeveloperRepository(_appDbContext);
    }
    public IDeveloperRepository Developers { get; private set; }

    public int Complete()
    {
        int res = _appDbContext.SaveChanges();
        return res;
    }

    public void Dispose()
    {
        _appDbContext.DisposeAsync();
    }
}