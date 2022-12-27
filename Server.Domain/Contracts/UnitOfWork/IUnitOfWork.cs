namespace Server.Domain.Contracts.UnitOfWork;

public interface IUnitOfWork
{
    void PerisistChanges();

    Task PerisistChangesAsync();

    int SaveChanges();

    Task<int> SaveChangesAsync();

    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();
}