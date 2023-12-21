using ApplicationLayer.DTO;
using AutoMapper;
using DomainLayer;
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
            CreateMap<Customer, CustomerAddModel>().ReverseMap();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
