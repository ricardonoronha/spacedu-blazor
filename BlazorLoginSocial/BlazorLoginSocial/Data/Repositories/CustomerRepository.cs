using BlazorLoginSocial.Domain.Dtos;
using BlazorLoginSocial.Domain.Entities;
using BlazorLoginSocial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorLoginSocial.Data.Repositories;

public class CustomerRepository(ApplicationDbContext dbContext)
    : BaseRepository<CustomerSearchDto, Customer>, ICustomerRepository
{
    public ApplicationDbContext DbContext { get; } = dbContext;

    public Task<Customer?> GetByIdAsync(Guid id)
    {
        return DbContext
            .Customers
            .FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task InsertOrUpdateAsync(CustomerInsertOrUpdateCommand command)
    {
        var customer = new Customer();

        if (command.Id == Guid.Empty)
        {
            customer.Id = Guid.NewGuid();
            DbContext.Add(customer);
        }
        else
        {
            customer = await GetByIdAsync(command.Id);

            if (customer is null)
            {
                throw new InvalidOperationException("Customer don't exists");
            }
        }

        customer.State = command.State;
        customer.Febraban = command.Febraban;
        customer.TownName = command.TownName;
        customer.Name = command.Name;
        customer.ImageUrl = command.ImageUrl;

        await DbContext.SaveChangesAsync();
    }

    public override IQueryable<Customer> MakeQuery(CustomerSearchDto filter)
    {
        return DbContext
            .Customers
            .Where(x => EF.Functions.Like(x.Name, $"%{filter.SearchWord}%") ||
                        EF.Functions.Like(x.TownName, $"%{filter.SearchWord}%"));
    }
}
