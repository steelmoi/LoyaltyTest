using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using loyaltytest.Infrastructure.Database.Repository;
using LoyaltyTest.Server.Utils.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IFileRepository fileRepository, IProductRepository productRepository) {
            _fileRepository = fileRepository;
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public IEnumerable<Product> GetList()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("/Product/{ProductId}")]
        public Product Get(long ProductId)
        {
            return _productRepository.GetProduct(ProductId);
        }

        [HttpPost("Add")]
        public ApiResult Add([FromBody] ProductRequest product)
        {
            ApiResult result = new ApiResult() { Status = 200 };

            try
            {
                result.Data = _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }

        [HttpPut("Update")]
        public ApiResult Update([FromBody] ProductRequest product)
        {
            ApiResult result = new ApiResult() { Status = 200 };

            try
            {
                result.Data = _productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = 500;
            }

            return result;
        }

        [HttpPost("/Product/Image/Link/{ProductId}")]
        public async Task<ApiResult> UploadExcel(IFormFile file, long ProductId)
        {
            ApiResult result = new ApiResult()
            {
                Status = 200
            };
            string url = "";
            try
            {
                var product = _productRepository.GetProduct(ProductId);
                var productRes = new ProductRequest();
                product.Image = await _fileRepository.UploadFile(file);

                productRes.ProductId = ProductId;
                productRes.UpdatedDate = DateTime.Now;
                productRes.Description = product.Description;
                productRes.Stock = product.Stock;
                productRes.Price = product.Price;
                productRes.Status = product.Status;
                productRes.SKUProduct = product.SKUProduct;
                productRes.Image = product.Image;
                product.Status = product.Status;

                result.Data = _productRepository.UpdateProduct(productRes);
            }
            catch (Exception ex)
            {
                result.Message=ex.Message;
                result.Status = 500;
            }
            return result;
        }

        [HttpGet("/Product/Image/{Src}")]
        public IResult GetImage(string Src)
        {
            IResult res =_fileRepository.DownloadImage(Src);
            return res;
        }
    }
}
