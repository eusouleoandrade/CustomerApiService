using CustomerApiWithService.Application.Exceptions;
using CustomerApiWithService.Application.Interfaces;
using CustomerApiWithService.Domain.Entities;
using CustomerApiWithService.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApiWithService.Infra.Persistence.Repositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        // Fields
        private readonly DbSet<Customer> _customer;

        // Ctors
        public CustomerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customer = _dbContext.Set<Customer>();
        }

        // Methods
        public async Task<bool> IsUniqueEmailAsync(string email)
        {
            try
            {
                return await _customer.AllAsync(p => p.Email != email);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }

        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            try
            {
                return await _customer.Where(f => f.Email == email).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }

        }

        public async override Task UpdateAsync(Customer entity)
        {
            try
            {
                DetachLocal(d => d.Id == entity.Id);
                await base.UpdateAsync(entity);
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
