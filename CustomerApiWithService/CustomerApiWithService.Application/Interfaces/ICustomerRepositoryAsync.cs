using CustomerApiWithService.Domain.Entities;
using System.Threading.Tasks;

namespace CustomerApiWithService.Application.Interfaces
{
    public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<Customer>
    {
        Task<bool> IsUniqueEmailAsync(string email);

        Task<Customer> GetByEmailAsync(string email);
    }
}
