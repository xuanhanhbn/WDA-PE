using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;

namespace WDA_PE.Repositories;

public class SubjectRepository : BaseRepository<Subject>
{
    public SubjectRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<Subject?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Subjects.FirstOrDefaultAsync(entity => entity.SubjectId.Equals(id), cancellationToken);
    }

    public override Task<Subject?> Create(Subject entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<Subject?> Update(Subject entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> Delete(Guid id, bool isHardDelete = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}