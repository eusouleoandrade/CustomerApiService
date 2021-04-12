using System.Collections.Generic;

namespace CustomerApiWithService.Application.DTOs.Customer
{
    public class CustomerAllData
    {
        // Properties
        public IEnumerable<CustomerData> Customers { get; set; }

        // Ctors
        public CustomerAllData(IEnumerable<CustomerData> customers)
        {
            Customers = customers;
        }
    }
}
