using BlazorLoginSocial.Domain.Dtos;
using BlazorLoginSocial.Domain.Entities;

namespace BlazorLoginSocial.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<PaginatedList<Customer>> SearchAsync(CustomerSearchDto search, CancellationToken cancellationToken);
    Task<Customer?> GetByIdAsync(Guid id);

    Task InsertOrUpdateAsync(CustomerInsertOrUpdateCommand command);
}
