using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }
        public async Task<ProductDto> GetItem(int id)
        {
            var product = await _shopOnlineDbContext.Products.Include(_ => _.ProductCategory).Where(x => x.Id == id).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageURL = x.ImageURL,
                Price = x.Price,
                Qty = x.Qty,
                CategoryId = x.ProductCategory.Id,
                CategoryName = x.ProductCategory.Name,
            }).FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            var products = await _shopOnlineDbContext.Products.Include(_=>_.ProductCategory).Select(x=>new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageURL = x.ImageURL,
                Price = x.Price,
                Qty = x.Qty,
                CategoryId = x.ProductCategory.Id,
                CategoryName = x.ProductCategory.Name,
            }).ToListAsync();
            
            return products;
        }
    }
}
