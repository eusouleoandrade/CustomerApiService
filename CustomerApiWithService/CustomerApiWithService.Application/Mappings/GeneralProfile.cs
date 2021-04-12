using AutoMapper;
using CustomerApiWithService.Application.DTOs.Customer;
using CustomerApiWithService.Domain.Entities;

namespace CustomerApiWithService.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, CustomerData>();
        }
    }
}
