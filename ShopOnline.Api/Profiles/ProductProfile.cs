using AutoMapper;
using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;


namespace ShopOnline.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CartItem, CartItemToAddDto>()
                .ForMember(dest=>dest.ProductId,src=>src.MapFrom(ent=>ent.Product.Id))
                .ForMember(dest=>dest.CartId,src=>src.MapFrom(ent=>ent.Cart.Id)).ReverseMap();
        }
    }
}
