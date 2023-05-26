using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;

namespace WDA_PE.Repositories;

public class ExamRepository : BaseRepository<Exam>
{
    public ExamRepository(AppDbContext context) : base(context)
    {
    }

    public override IQueryable<Exam> Get(Expression<Func<Exam, bool>>? expression = null, int size = 10, int page = 0)
    {
        return base.Get(expression, size, page)
            .Include(x => x.Subject)
            .Include(x => x.Faculty)
            .Include(x => x.Classroom);
    }

    public override async Task<Exam?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Exams.FirstOrDefaultAsync(e => e.ExamId.Equals(id), cancellationToken); 
    }

    public override async Task<Exam?> Create(Exam entity, CancellationToken cancellationToken = default)
    {
        var isEntityExisted = await Context.Exams.AnyAsync(e => e.ExamId.Equals(entity.ExamId), cancellationToken);
        if (isEntityExisted)
        {
            throw new Exception($"Entity existed!");
        }

        var result = Context.Exams.Add(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public override Task<Exam?> Update(Exam entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> Delete(Guid id, bool isHardDelete = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}