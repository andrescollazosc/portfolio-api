namespace IdeaCompany.Portfolio.Core.Common.Data;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}