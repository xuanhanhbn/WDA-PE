using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;

namespace WDA_PE.Repositories;

public class FacultyRepository : BaseRepository<Faculty>
{
    public FacultyRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<Faculty?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Faculties.FirstOrDefaultAsync(entity => entity.FacultyId.Equals(id), cancellationToken);
    }

    public override Task<Faculty?> Create(Faculty entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<Faculty?> Update(Faculty entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> Delete(Guid id, bool isHardDelete = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}