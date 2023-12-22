using ApplicationLayer.DTO;
using AutoMapper;
using DomainLayer;
using DomainLayer.Enities;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AllCustomerResponseModel, AllCustomerResModel>()
                 .ForMember(dest => dest.Continant, opt => opt.MapFrom(src => src.RegionDetails.Continents))
                 .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.RegionDetails.RegionName));
               
              // Map other properties of RegionDetails as needed
             //   .ForMember(dest => dest.RegionDetails, opt => opt.Ignore()); // Ignore the original RegionDetails property;


            CreateMap<CustomerDetailsResModel, SingleCustomerResModel>();
            //      .ForAllMembers();

            // CreateMap<CustomerDetailsResModel, AllCustomerResModel>();


            CreateMap<OrderReqModel, OrderAddModel>();
            CreateMap<AccountReqModel, Account>();
            CreateMap<CustomerReqModel, CustomerAddModel>();
            CreateMap<ProductAddModel, Product>();
        }
    }
}
