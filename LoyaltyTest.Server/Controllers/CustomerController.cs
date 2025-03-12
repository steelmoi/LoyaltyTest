using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("")]
        public IEnumerable<Customer> GetList()
        {
            return _customerRepository.GetAll();
        }

        [HttpGet("/Customer/{CustomerId}")]
        public Customer Get(long CustomerId)
        {
            return _customerRepository.Get(CustomerId);
        }

        [HttpPost("Add")]
        public ApiResult Add([FromBody] CustomerRequest customer)
        {
            ApiResult result = new ApiResult() { Status = 200 };

            try
            {
                result.Data = _customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }

        [HttpPut("Update")]
        public ApiResult Update([FromBody] CustomerRequest customer)
        {
            ApiResult result = new ApiResult() {Status = 200 };

            try
            {
                _customerRepository.UpdateCustomer(customer);
                result.Data = customer;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }
    }
}
