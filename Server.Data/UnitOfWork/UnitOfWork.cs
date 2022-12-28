using Microsoft.EntityFrameworkCore;
using Server.Domain.Contracts.UnitOfWork;

namespace Server.Data.UnitOfWork;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;

    public UnitOfWork(TContext context) => this._context = context;

    public void PerisistChanges() => this._context.SaveChanges();

    public async Task PerisistChangesAsync()
    {
        int num = await this._context.SaveChangesAsync(new CancellationToken());
    }

    public int SaveChanges() => !this._context.ChangeTracker.HasChanges() ? 1 : this._context.SaveChanges();

    public async Task<int> SaveChangesAsync()
    {
        int num;
        if (this._context.ChangeTracker.HasChanges())
            num = await this._context.SaveChangesAsync(new CancellationToken());
        else
            num = 1;
        return num;
    }

    public void Dispose() => this.Dispose(true);

    public void BeginTransaction() => this._context.Database.BeginTransaction();

    public void CommitTransaction()
    {
        try
        {
            this._context.Database.CurrentTransaction.Commit();
        }
        catch (Exception ex)
        {
            this.RollbackTransaction();
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public void RollbackTransaction() => this._context.Database.CurrentTransaction.Rollback();

    private void Dispose(bool disposing)
    {
        if (!disposing)
            return;
        this._context?.Dispose();
    }
}

