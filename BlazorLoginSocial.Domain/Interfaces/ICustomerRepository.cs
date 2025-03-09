using BlazorLoginSocial.Domain.Dtos;
using BlazorLoginSocial.Domain.Entities;

namespace BlazorLoginSocial.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<PaginatedList<Customer>> SearchAsync(CustomerSearchDto search, CancellationToken cancellationToken);
}
