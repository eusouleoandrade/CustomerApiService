using CustomerApiWithService.Application.Interfaces;
using CustomerApiWithService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApiWithService.Application.Services
{
    public class CustomerService : ValuableBaseService, ICustomerService
    {
        // Fields
        private readonly ICustomerRepositoryAsync _customerRepository;

        // Ctors
        public CustomerService(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Methods
        public async Task<Customer> AddAsync(Customer entity)
        {
            _validationResult = new List<string>();

            if (entity is null)
            {
                _validationResult.Add($"{nameof(Customer)} inválido");
            }
            else
            {
                if (entity.Invalid)
                {
                    _validationResult.AddRange(entity.ValidationResult);
                }
                else
                {
                    if (!await IsUniqueEmail(entity))
                        _validationResult.Add($"E-mail já cadastrado");

                    if (Valid)
                        return await _customerRepository.AddAsync(entity);
                }
            }

            return null;
        }

        public async Task DeleteAsync(Guid id)
        {
            _validationResult = new List<string>();

            if (id == Guid.Empty)
            {
                _validationResult.Add("Identificador inválido");
            }
            else
            {
                var entity = await GetByIdAsync(id);

                if (Valid)
                    await _customerRepository.DeleteAsync(entity);
            }
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            _validationResult = new List<string>();

            if (id == Guid.Empty)
            {
                _validationResult.Add("Identificador inválido");
            }
            else
            {
                var entity = await _customerRepository.GetByIdAsync(id);

                if (entity is null)
                    _validationResult.Add($"{nameof(Customer)} não localizado");

                if (Valid)
                    return entity;
            }

            return null;
        }

        public async Task UpdateAsync(Customer entity)
        {
            _validationResult = new List<string>();

            if (entity is null)
            {
                _validationResult.Add($"{nameof(Customer)} inválido");
            }
            else
            {
                if (entity.Invalid)
                {
                    _validationResult.AddRange(entity.ValidationResult);
                }
                else
                {
                    if (await GetByIdAsync(entity.Id) != null)
                    {
                        if (!await IsUniqueEmail(entity))
                            _validationResult.Add($"E-mail já cadastrado");

                        if (Valid)
                            await _customerRepository.UpdateAsync(entity);
                    }
                }
            }
        }

        private async Task<bool> IsUniqueEmail(Customer entity)
        {
            var entityByEmail = await _customerRepository.GetByEmailAsync(entity.Email);

            if (entityByEmail is null)
                return true;
            else
                if (entityByEmail.Id == entity.Id)
                return true;

            return false;
        }
    }
}
