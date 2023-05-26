using System.Linq.Expressions;

namespace WDA_PE.Repositories;

public interface IRepository<T> where T: class
{
    public IQueryable<T> Get(Expression<Func<T, bool>>? expression = null ,int size = 10, int page = 0);
    public Task<T?> GetById(Guid id, CancellationToken cancellationToken = default);
    public Task<T?> Create(T entity, CancellationToken cancellationToken = default);
    public Task<T?> Update(T entity, CancellationToken cancellationToken = default);
    public Task<bool> Delete(Guid id, bool isHardDelete = false, CancellationToken cancellationToken = default);
}