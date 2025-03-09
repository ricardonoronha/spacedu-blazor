using BlazorLoginSocial.Domain.Dtos;
using BlazorLoginSocial.Domain.Entities;
using BlazorLoginSocial.Domain.Interfaces;
using System.Net.Http.Json;

namespace BlazorLoginSocial.Client.Repositories; 

public class CustomerHttpRepsitory(HttpClient httpClient) : ICustomerRepository
{
    public HttpClient HttpClient { get; } = httpClient;

    async Task<PaginatedList<Customer>> ICustomerRepository.SearchAsync(CustomerSearchDto search, CancellationToken cancellationToken)
    {
        var url = $"/api/customers/searchWord={search.SearchWord}&pageIndex={search.PageIndex}&pageSize={search.PageSize}";

        var result = await HttpClient
            .GetFromJsonAsync<PaginatedList<Customer>>(url, cancellationToken);

        return result!;
    }
}
