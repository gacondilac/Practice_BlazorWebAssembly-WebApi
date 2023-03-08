using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartReporitory
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;
        private readonly IMapper _mapper;

        public ShoppingCartRepository(ShopOnlineDbContext shopOnlineDbContext, IMapper mapper)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
            _mapper = mapper;
        }
        public async Task<CartItemToAddDto> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            //var item =await _shopOnlineDbContext.CartItems
            //    .Include(_=>_.Product).Include(_=>_.Cart)
            //    .Where(x=>x.Product.Id==cartItemToAddDto.ProductId)
            //    .Select(x => new CartItemToAddDto
            //    {
            //        Qty= x.Qty,
            //        CartId= x.Id,
            //        ProductId=x.Product.Id,
            //    }).SingleOrDefaultAsync();
            var cart = await _shopOnlineDbContext.Carts.FindAsync(cartItemToAddDto.CartId);
            var product=await _shopOnlineDbContext.Products.FindAsync(cartItemToAddDto.ProductId);

            if (cart==null && product ==null)
            {
                return null;
            }
            var newCartItem = new CartItem
            {
                Qty = cartItemToAddDto.Qty,
                Cart = cart,
                Product = product
            };
            //var cartItem = _mapper.Map<CartItem>(cartItemToAddDto);
            _shopOnlineDbContext.CartItems.AddAsync(newCartItem);
            await _shopOnlineDbContext.SaveChangesAsync();
            return _mapper.Map<CartItemToAddDto>(newCartItem);
           
            return null;
        }

        public Task<CartItem> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
