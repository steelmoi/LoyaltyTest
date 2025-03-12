using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IAddressStoreRepository _addressStoreRepository;

        public AddressController(IAdressRepository adressRepository,
            IAddressStoreRepository addressStoreRepository
            ) {
            _adressRepository = adressRepository;
            _addressStoreRepository = addressStoreRepository;
        }

        #region Address Customer
        [HttpGet("")]
        public IEnumerable<Address> GetList()
        {
            return _adressRepository.GetAll();
        }

        [HttpGet("/Address/{AddressID}")]
        public Address Get(long AddressID)
        {
            return _adressRepository.Get(AddressID);
        }

        [HttpPost("Add")]
        public ApiResult AddAddress([FromBody]AddressRequest address)
        {
            ApiResult result = new ApiResult() { Status = 200 };

            try
            {
                result.Data = _adressRepository.AddAddress(address);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status   = 500;
            }

            return result;
        }

        [HttpPut("Update")]
        public ApiResult Update([FromBody] AddressRequest address)
        {
            ApiResult result = new ApiResult() {Status = 200};

            try
            {                
                result.Data = _adressRepository.UpdateAddress(address);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }

        #endregion Address Customer

        #region Address Store
        [HttpGet("/Address/Store")]
        public IEnumerable<AddressStore> GetListAddressStore()
        {
            return _addressStoreRepository.GetAll();
        }

        [HttpGet("/Address/Store/{AddressID}")]
        public AddressStore GetAddressStore(long AddressID)
        {
            return _addressStoreRepository.Get(AddressID);
        }

        [HttpPost("/Address/Store/Add")]
        public ApiResult AddAddressStore([FromBody] AddressRequest address)
        {
            ApiResult result = new ApiResult() { Status = 200 };

            try
            {
                result.Data = _addressStoreRepository.AddAddress(address);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }

        [HttpPut("/Address/Store/Update")]
        public ApiResult UpdateAddressStore([FromBody] AddressRequest address)
        {
            ApiResult result = new ApiResult() { Status = 200 };

            try
            {
                result.Data = _addressStoreRepository.UpdateAddress(address);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }

        #endregion Address Store
    }
}
