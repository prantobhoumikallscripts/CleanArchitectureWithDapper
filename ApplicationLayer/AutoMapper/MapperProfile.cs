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
            // CreateMap<CustomerAddModel, CustomerDetailsResModel>();
            //CreateMap<AllCustomerResponseModel, AllCustomerResModel>()
            //      .ForAllMembers();
            //CreateMap<CustomerDetailsResModel, SingleCustomerResModel>()
            //      .ForAllMembers();

            CreateMap<CustomerDetailsResModel, AllCustomerResModel>();


            CreateMap<OrderReqModel, OrderAddModel>();
            CreateMap<AccountReqModel, Account>();
            CreateMap<CustomerReqModel, CustomerAddModel>();
            CreateMap<ProductAddModel, Product>();

            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
