using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Infrastructure.Database.Repository
{
    public class ProductRepository:DbManager<Product>, IProductRepository
    {
        public ProductRepository(LoyaltyDBContext dBContext) :base(dBContext) { }

        public Product AddProduct(ProductRequest product)
        {
            Product prod = new Product()
            {
                CreatedDate = DateTime.Now,
                Description = product.Description,
                Image = string.Empty,
                Price = product.Price,
                ProductId = 0,
                SKUProduct = product.SKUProduct,
                Status  = product.Status,
                UpdatedDate = DateTime.Now,
                Stock = product.Stock
            };

            return this.AddEntity(prod);
        }

        public List<Product> GetAll()
        {
            return this.dbContext
                .Product                
                .ToList();
        }

        public Product GetProduct(long ProductId)
        {
            return this.dbContext
                .Product
                .Where(P => P.ProductId == ProductId)
                .FirstOrDefault();
        }

        public Product UpdateProduct(ProductRequest product)
        {

            Product prod = this.dbContext.Product
                             .Where(P => P.ProductId == product.ProductId)
                             .FirstOrDefault();

            prod.SKUProduct = product.SKUProduct;
            prod.Status = product.Status;
            prod.UpdatedDate = DateTime.Now;
            prod.Description = product.Description;
            prod.Image = product.Image;
            prod.Price = product.Price;
            prod.Stock = product.Stock;

            this.Update(prod);
            return prod;
        }
    }
}
