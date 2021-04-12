using System;

namespace CustomerApiWithService.Application.DTOs.Customer
{
    public class CustomerData
    {
        // Properties
        public virtual Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
