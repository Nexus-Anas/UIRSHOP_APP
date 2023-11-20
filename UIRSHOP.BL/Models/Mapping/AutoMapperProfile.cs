using AutoMapper;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.BL.Models.Dtos.ClientDtos;
using UIRSHOP.BL.Models.Dtos.DetailsFactureDto;
using UIRSHOP.BL.Models.Dtos.FactureDto;
using UIRSHOP.BL.Models.Dtos.OrderDtos;
using UIRSHOP.BL.Models.Dtos.OrderproductDtos;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.Models.Dtos.StockDtos;
using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Models.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<SupplierDto, Supplier>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<FactureDto, Facture>().ReverseMap();
            CreateMap<DetailsFactureDto, DetailsFacture>().ReverseMap();
            CreateMap<OrderproductDto, Orderproduct>().ReverseMap();
        }
    }
}
