﻿using e_Shop_Demo.Entities;
using e_Shop_Demo.IRepository;

namespace e_Shop_Demo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public LibraryDbContext LibraryDbContext { get; }
        public EmployeeRepository Employee => new EmployeeRepository(LibraryDbContext);

        public CustomerRepository Customer => new CustomerRepository(LibraryDbContext);

        public ProductRepository Product => new ProductRepository(LibraryDbContext);

        public ProductTypesRepository ProductType => new ProductTypesRepository(LibraryDbContext);

        public SupplierRepository Supplier => new SupplierRepository(LibraryDbContext);

        public ImportRecordRepository ImportRecord => new ImportRecordRepository(LibraryDbContext);

        public PurchaseRecordRepository PurchaseRecord => new PurchaseRecordRepository(LibraryDbContext);

        public RepositoryWrapper(LibraryDbContext libraryDbContext)
        {
            LibraryDbContext = libraryDbContext;
        }
    }
}
