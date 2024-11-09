public interface IUnitOfWork : IDisposable
{
    IDeveloperRepository Developers { get; }
    int Complete();
}