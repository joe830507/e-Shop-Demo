using e_Shop_Demo.Entities;
using e_Shop_Demo.IRepository;

namespace e_Shop_Demo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public LibraryDbContext LibraryDbContext { get; }
        public EmployeeRepository Employee => new EmployeeRepository(LibraryDbContext);
        public RepositoryWrapper(LibraryDbContext libraryDbContext)
        {
            LibraryDbContext = libraryDbContext;
        }
    }
}
