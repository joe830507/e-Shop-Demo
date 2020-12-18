using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Helpers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            //Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForLoginDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }
    }
}
