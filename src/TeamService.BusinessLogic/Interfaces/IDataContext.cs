namespace TeamService.BusinessLogic.Interfaces;

public interface IDataContext
{
    public Task SaveChangesAsync(CancellationToken token);
}
