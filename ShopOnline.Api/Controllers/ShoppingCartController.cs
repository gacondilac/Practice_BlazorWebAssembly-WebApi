using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartReporitory _shoppingCartReporitory;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCartReporitory shoppingCartReporitory, IProductRepository productRepository)
        {
            _shoppingCartReporitory = shoppingCartReporitory;
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CartItemToAddDto>>> PostItem( CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var newCartItem =await _shoppingCartReporitory.AddItem(cartItemToAddDto);
                if(newCartItem == null)
                {
                    return NoContent();
                }
                    return Ok(newCartItem);
                
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
