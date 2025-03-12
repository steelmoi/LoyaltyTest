using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        
        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;

        }

        [HttpGet("")]
        //public IEnumerable<Store> GetList()
        public IActionResult GetList()
        {
            return Ok(_storeRepository.GetAll());
        }

        [HttpGet("/Store/{StoreID}")]
        public Store Get(long StoreID)
        {
            return _storeRepository.Get(StoreID);
        }

        [HttpPost("Add")]
        public ApiResult AddStore([FromBody] StoreRequest store)
        {
            ApiResult apiResult = new ApiResult()
            {
                Status = 200
            };

            try
            {
                apiResult.Data = _storeRepository.AddStore(store);
            }
            catch (Exception ex)
            {
                apiResult.Status = 500;
                apiResult.Message = ex.Message;
            }

            return apiResult;
        }

        [HttpPut("Update")]
        public ApiResult PutStore([FromBody] StoreRequest store)
        {
            ApiResult apiResult = new ApiResult() { Status = 200 };

            try
            {                
                apiResult.Data= _storeRepository.UpdateStore(store);
            }
            catch (Exception ex)
            {
                apiResult.Status = 500;
                apiResult.Message = ex.Message;
            }
            return apiResult;
        }

        [HttpPost("/Store/Product/Add")]
        public ApiResult AddProductStore([FromBody] ProductStore product)
        {
            ApiResult result = new ApiResult()
            {
                Status = 200
            };

            try
            {
                _storeRepository.AddProduct2Store(product);
                result.Data = product;
            }catch(Exception Err)
            {
                result.Status = 500;
                result.Message = Err.Message;
            }

            return result;
        }
    }
}
