using BlazorLoginSocial.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlazorLoginSocial.Data.Repositories;

public abstract class BaseRepository<TFilter, TResult>
{
    public async Task<PaginatedList<TResult>> SearchAsync(PaginatedSearchDto<TFilter> search, CancellationToken cancellationToken)
    {
        var query = MakeQuery(search.Filter);

        int totalItems = await query.CountAsync(cancellationToken);

        int pageSize = search.PageSize == 0 ? 1 : search.PageSize;

        int pageIndex = search.PageIndex <= 0 ? 1 : search.PageIndex;

        int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

        var items = await query
            .Skip((pageIndex -1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<TResult>(pageIndex, pageSize, items, totalItems, totalPages);
    }

    public abstract IQueryable<TResult> MakeQuery(TFilter filter);

}
