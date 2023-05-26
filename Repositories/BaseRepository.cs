using System.Linq.Expressions;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace WDA_PE.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected AppDbContext Context { get; private set; }

    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public virtual IQueryable<T> Get(Expression<Func<T, bool>>? expression = null, int size = 10, int page = 0)
    {
        if (expression == null)
        {
            return Context.Set<T>().Skip(page).Take(size).AsQueryable();
        }

        return Context.Set<T>().Where(expression).Skip(page).Take(size).AsQueryable();
    }

    public abstract Task<T?> GetById(Guid id, CancellationToken cancellationToken = default);

    public abstract Task<T?> Create(T entity, CancellationToken cancellationToken = default);

    public abstract Task<T?> Update(T entity, CancellationToken cancellationToken = default);

    public abstract Task<bool> Delete(Guid id, bool isHardDelete = false,
        CancellationToken cancellationToken = default);
}