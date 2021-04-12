using CustomerApiWithService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApiWithService.Application.Interfaces
{
    public interface ICustomerService
    {
        bool Valid { get; }

        bool Invalid { get; }

        List<string> ValidationResult { get; }

        Task<Customer> GetByIdAsync(Guid id);

        Task<IReadOnlyList<Customer>> GetAllAsync();

        Task<Customer> AddAsync(Customer entity);

        Task UpdateAsync(Customer entity);

        Task DeleteAsync(Guid id);
    }
}
