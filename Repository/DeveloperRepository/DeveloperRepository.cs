public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
{
    
    public DeveloperRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}