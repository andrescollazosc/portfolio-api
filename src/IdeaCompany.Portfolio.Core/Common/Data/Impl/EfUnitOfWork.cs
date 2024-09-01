using Microsoft.EntityFrameworkCore;

namespace IdeaCompany.Portfolio.Core.Common.Data.Impl;

public class EfUnitOfWork<T> : IUnitOfWork where T : DbContext
{
    private T DbContext { get; }

    public EfUnitOfWork(T dbContext)
    {
        DbContext = dbContext;
    }

    public void Commit()
    {
        DbContext.SaveChanges();
    }
    
    public async Task CommitAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    public void Rollback()
    {
        DbContext.Dispose();
    }

    public async Task RollbackAsync()
    {
        await DbContext.DisposeAsync();
    }
}