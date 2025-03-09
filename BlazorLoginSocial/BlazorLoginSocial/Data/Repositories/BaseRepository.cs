using BlazorLoginSocial.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlazorLoginSocial.Data.Repositories;

public abstract class BaseRepository<TFilter, TResult>
    where TFilter : IPaginatedSearchDto
{
    public const int DEFAULT_PAGE_SIZE = 15;
    public async Task<PaginatedList<TResult>> SearchAsync(TFilter search, CancellationToken cancellationToken)
    {
        var query = MakeQuery(search);

        int totalItems = await query.CountAsync(cancellationToken);

        int pageSize = search.PageSize.GetValueOrDefault(DEFAULT_PAGE_SIZE);

        if (pageSize <= 0) pageSize = DEFAULT_PAGE_SIZE;

        int pageIndex = search.PageIndex.GetValueOrDefault(1);

        if (pageIndex <= 0) pageIndex = 1;

        int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

        var items = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<TResult>(pageIndex, pageSize, items, totalItems, totalPages);
    }

    public abstract IQueryable<TResult> MakeQuery(TFilter filter);

}
