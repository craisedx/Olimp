using AutoMapper;
using Olimp.ViewModels.Basket;
using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Category;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;

namespace Olimp.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandViewModel, Models.Brand>()
                   .ForMember(b => b.Id, opt => opt.MapFrom(bvm => bvm.Id))
                   .ForMember(b => b.Image, opt => opt.MapFrom(bvm => bvm.Image))
                   .ForMember(b => b.Description, opt => opt.MapFrom(bvm => bvm.Description))
                   .ForMember(b => b.ProductBrand, opt => opt.MapFrom(bvm => bvm.ProductBrand))
                   .ForMember(b => b.Products, opt => opt.Ignore())
                   .ReverseMap();
            CreateMap<CategoryViewModel, Models.Category>()
                .ForMember(c => c.Id, opt => opt.MapFrom(cvm => cvm.Id))
                .ForMember(c => c.ProductCategory, opt => opt.MapFrom(cvm => cvm.ProductCategory))
                .ForMember(c => c.Products, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ProductViewModel, Models.Product>()
                .ForMember(p => p.Id, opt => opt.MapFrom(pvm => pvm.Id))
                .ForMember(p => p.Brand, opt => opt.MapFrom(pvm => pvm.Brand))
                .ForMember(p => p.BrandId, opt => opt.MapFrom(pvm => pvm.BrandId))
                .ForMember(p => p.Category, opt => opt.Ignore())
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(pvm => pvm.CategoryId))
                .ForMember(p => p.Description, opt => opt.MapFrom(pvm => pvm.Description))
                .ForMember(p => p.Image, opt => opt.MapFrom(pvm => pvm.Image))
                .ForMember(p => p.StoreWarehouses, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Models.BasketStoreWarehouse, BasketStoreWarehouseViewModel>()
                .ForMember(bsw => bsw.Id, opt => opt.MapFrom(bswvm => bswvm.Id))
                .ForMember(bsw => bsw.Quantity, opt => opt.MapFrom(bswvm => bswvm.Quantity))
                .ForMember(bsw => bsw.StoreWarehouse, opt => opt.MapFrom(bswvm => bswvm.StoreWarehouse))
                .ForMember(bsw => bsw.Basket, opt => opt.MapFrom(bswvm => bswvm.Basket))
                .ForMember(bsw => bsw.StoreWarehouseId, opt => opt.MapFrom(bswvm => bswvm.StoreWarehouseId))
                .ForMember(bsw => bsw.BasketId, opt => opt.MapFrom(bswvm => bswvm.BasketId))
                .ForMember(bsw => bsw.UserId, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<BasketViewModel, Models.Basket>()
                .ForMember(b => b.Id, opt => opt.MapFrom(bvm => bvm.Id))
                .ForMember(b => b.User, opt => opt.MapFrom(bvm => bvm.User))
                .ForMember(b => b.UserId, opt => opt.MapFrom(bvm => bvm.UserId))
                .ForMember(b => b.StoreWarehouses, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<StoreWarehouseViewModel, Models.StoreWarehouse>()
                .ForMember(sw => sw.Id, opt => opt.MapFrom(swvm => swvm.Id))
                .ForMember(sw => sw.Discount, opt => opt.MapFrom(swvm => swvm.Discount))
                .ForMember(sw => sw.Price, opt => opt.MapFrom(swvm => swvm.Price))
                .ForMember(sw => sw.Product, opt => opt.MapFrom(swvm => swvm.Product))
                .ForMember(sw => sw.ProductId, opt => opt.MapFrom(swvm => swvm.ProductId))
                .ForMember(sw => sw.Quantity, opt => opt.MapFrom(swvm => swvm.Quantity))
                .ForMember(sw => sw.Baskets, opt => opt.Ignore())
                .ForMember(sw => sw.Orders, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}