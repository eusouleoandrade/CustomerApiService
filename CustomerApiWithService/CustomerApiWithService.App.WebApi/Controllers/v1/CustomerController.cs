using AutoMapper;
using CustomerApiWithService.Application.DTOs.Common;
using CustomerApiWithService.Application.DTOs.Customer;
using CustomerApiWithService.Application.Interfaces;
using CustomerApiWithService.Application.Mappings;
using CustomerApiWithService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApiWithService.App.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        // Fields
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        // Ctors
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<Response<CustomerAllData>>> Get()
        {
            var customerAllData = new CustomerAllData((await _customerService.GetAllAsync()).Select(s => _mapper.Map<CustomerData>(s)));
            return new Response<CustomerAllData>(_customerService.Valid, customerAllData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<CustomerData>>> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelStateErrorsResponse());

            var customer = await _customerService.GetByIdAsync(id);

            if (_customerService.Valid)
            {
                var response = new Response<CustomerData>(_customerService.Valid, _mapper.Map<CustomerData>(customer));
                return Ok(response);
            }

            return BadRequest(new Response(_customerService.Valid, _customerService.ValidationResult));
        }

        [HttpPost]
        public async Task<ActionResult<Response<CustomerData>>> Post([FromBody] CustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelStateErrorsResponse());

            var customer = await _customerService.AddAsync(_mapper.Map<Customer>(request));

            if (_customerService.Valid)
            {
                var response = new Response<CustomerData>(_customerService.Valid, _mapper.Map<CustomerData>(customer));
                return Created($"/api/v1/Customer/{customer.Id}", response);
            }

            return BadRequest(new Response(_customerService.Valid, _customerService.ValidationResult));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(Guid id, [FromBody] CustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelStateErrorsResponse());

            await _customerService.UpdateAsync(request.ToCustomer(id));

            if (_customerService.Valid)
                return Ok(new Response(_customerService.Valid));

            return BadRequest(new Response(_customerService.Valid, _customerService.ValidationResult));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelStateErrorsResponse());

            await _customerService.DeleteAsync(id);

            if (_customerService.Valid)
                return Ok(new Response(_customerService.Valid));

            return BadRequest(new Response(_customerService.Valid, _customerService.ValidationResult));
        }
    }
}
