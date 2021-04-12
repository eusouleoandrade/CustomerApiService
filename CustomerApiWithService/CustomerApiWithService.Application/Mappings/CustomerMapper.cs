using CustomerApiWithService.Application.DTOs.Customer;
using CustomerApiWithService.Domain.Entities;
using System;

namespace CustomerApiWithService.Application.Mappings
{
    public static class CustomerMapper
    {
        public static Customer ToCustomer(this CustomerRequest request, Guid id)
        {
            return new Customer(id, request.FirstName, request.LastName, request.Email, request.Phone);
        }
    }
}
