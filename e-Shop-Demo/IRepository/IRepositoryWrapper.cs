using e_Shop_Demo.Repository;


namespace e_Shop_Demo.IRepository
{
    public interface IRepositoryWrapper
    {
        public EmployeeRepository Employee { get; }
        public CustomerRepository Customer { get; }
        public ProductRepository Product { get; }
        public ProductTypesRepository ProductType { get; }
        public SupplierRepository Supplier { get; }
        public ImportRecordRepository ImportRecord { get; }
        public PurchaseRecordRepository PurchaseRecord { get; }

    }
}
