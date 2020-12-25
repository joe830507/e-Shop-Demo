using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Enums;
using System;

namespace e_Shop_Demo.Helpers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            //Employee
            CreateMap<Employee, EmployeeForDisplayDto>()
                .ForMember(e => e.Role, item =>
                           item.MapFrom(i => Enum.GetName(typeof(Role), i.Role)))
                .ForMember(e => e.Activate, item =>
                           item.MapFrom(i => i.Activate == true ? "啟用" : "未啟用"));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForLoginDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            //Customer
            CreateMap<CustomerForLoginDto, Customer>();
            //Product
            CreateMap<Product, ProductDto>();
        }
    }
}
