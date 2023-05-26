using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;

namespace WDA_PE.Repositories;

public class ClassroomRepository : BaseRepository<Classroom>
{
    public ClassroomRepository(AppDbContext context) : base(context)
    {
    }


    public override async Task<Classroom?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Classrooms.FirstOrDefaultAsync(entity => entity.ClassroomId.Equals(id), cancellationToken);
    }

    public override Task<Classroom?> Create(Classroom entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<Classroom?> Update(Classroom entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> Delete(Guid id, bool isHardDelete = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}