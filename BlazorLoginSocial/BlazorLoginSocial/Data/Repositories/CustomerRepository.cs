using BlazorLoginSocial.Domain.Dtos;
using BlazorLoginSocial.Domain.Entities;
using BlazorLoginSocial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorLoginSocial.Data.Repositories;

public class CustomerRepository(ApplicationDbContext dbContext)
    : BaseRepository<CustomerSearchDto, Customer>, ICustomerRepository
{
    public ApplicationDbContext DbContext { get; } = dbContext;

    public override IQueryable<Customer> MakeQuery(CustomerSearchDto filter)
    {
        return DbContext
            .Customers
            .Where(x => EF.Functions.Like(x.Name, $"%{filter.SearchWord}%") ||
                        EF.Functions.Like(x.TownName, $"%{filter.SearchWord}%"));
    }
}
