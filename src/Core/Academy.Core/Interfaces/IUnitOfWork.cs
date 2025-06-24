namespace Academy.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
