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
            CreateMap<ProductAddModel, Product>();
            CreateMap<AllCustomerResponseModel, AllCustomerResModel>()
                 .ForMember(dest => dest.Continant, opt => opt.MapFrom(src => src.RegionDetails.Continents))
                 .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.RegionDetails.RegionName));

            // Map other properties of RegionDetails as needed
            //   .ForMember(dest => dest.RegionDetails, opt => opt.Ignore()); // Ignore the original RegionDetails property;

            CreateMap<Account, AccountResModel>().ForMember(dest=>dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNo));
            CreateMap<CustomerDetailsResModel, SingleCustomerResModel>();

            CreateMap<OrderReqModel, OrderAddModel>();
            CreateMap<AccountReqModel, Account>();
            CreateMap<CustomerReqModel, CustomerAddModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.VillageOrRoadName +","+src.PostOffice + "," + src.PoliceStation + "," + src.District + "," + src.City+","+src.PinCode))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.ToString()));
           
        }
    }
}
