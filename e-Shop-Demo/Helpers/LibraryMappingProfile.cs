﻿using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Dtos.Customer;
using e_Shop_Demo.Dtos.ImportRecord;
using e_Shop_Demo.Dtos.Product;
using e_Shop_Demo.Dtos.PurchaseRecord;
using e_Shop_Demo.Dtos.Supplier;
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
                .ForMember(e => e.CreateTime, item =>
                           item.MapFrom(i => i.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForLoginDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            //Customer
            CreateMap<CustomerForLoginDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<Customer, CustomerForDisplayDto>()
                .ForMember(e => e.BirthDate, item =>
                           item.MapFrom(i => i.BirthDate.ToString("yyyy-MM-dd")))
                .ForMember(e => e.CreateTime, item =>
                           item.MapFrom(i => i.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            //Product
            CreateMap<Product, ProductForDisplayDto>()
                .ForMember(e => e.CreateTime, item =>
                           item.MapFrom(i => i.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")))
                .ForMember(e => e.Type, item =>
                           item.MapFrom(i => i.ProductType.Name));
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
            //ProductTypeID
            CreateMap<ProductTypeForCreationDto, ProductType>();
            //Supplier
            CreateMap<Supplier, SupplierForDisplayDto>()
                .ForMember(e => e.CreateTime, item =>
                           item.MapFrom(i => i.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            CreateMap<SupplierForUpdateDto, Supplier>();
            CreateMap<SupplierForCreationDto, Supplier>();
            //ImportRecord
            CreateMap<ImportRecordForCreationDto, ImportRecord>();
            CreateMap<ImportRecordForUpdateDto, ImportRecord>();
            CreateMap<ImportRecord, ImportRecordForDisplayDto>()
                .ForMember(e => e.CreateTime, item =>
                           item.MapFrom(i => i.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            //PurchaseRecord
            CreateMap<PurchaseRecord, PurchaseRecordForDisplayDto>()
                .ForMember(e => e.CreateTime, item =>
                           item.MapFrom(i => i.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")))
                .ForMember(e => e.PurchaseDate, item =>
                           item.MapFrom(i => i.PurchaseDate.ToString("yyyy-MM-dd hh:mm:ss")))
                .ForMember(e => e.CustomerID, item =>
                           item.MapFrom(i => i.CustomerID));
            CreateMap<PurchaseDetailRecord, PurchaseDetailRecordForDisplayDto>()
                .ForMember(e => e.ProductName, item =>
                           item.MapFrom(i => i.Product.Name));
        }
    }
}
