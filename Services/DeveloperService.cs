
public class DeveloperService : IDeveloperService
{
    private readonly IUnitOfWork _unitOfWork;
    public DeveloperService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Create(Developer developer)
    {
        if (developer is null)
            return false;

        await _unitOfWork.Developers.Create(developer);
        int res = _unitOfWork.Complete();
        return res is 0
        ? false
        : true;
    }

    public async Task<bool> Delete(int id)
    {
        Developer? developer = await _unitOfWork.Developers.GetById(id);
        if (developer is null)
            return false;
        await _unitOfWork.Developers.Delete(developer);
        int res = _unitOfWork.Complete();
        return res is 0
        ? false
        : true;
    }

    public async Task<IEnumerable<Developer>> GetAll()
    {
        IEnumerable<Developer> developers = await _unitOfWork.Developers.GetAll();
        return developers is null
        ? null!
        : developers;
    }

    public async Task<Developer> GetById(int id)
    {
        Developer? developer = await _unitOfWork.Developers.GetById(id);
        return developer is null
        ? null!
        : developer;
    }

    public async Task<bool> Update(Developer developer)
    {
        Developer? developerUpdate = await _unitOfWork.Developers.GetById(developer.Id);
        if (developerUpdate is null)
            return false;
        developerUpdate.Name = developer.Name;
        developerUpdate.Followers = developer.Followers;
        int res = _unitOfWork.Complete();
        return res is 0
        ? false
        : true;
    }
}