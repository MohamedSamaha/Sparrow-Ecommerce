using SparrowManagementSystem.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowManagementSystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository Products { get; set; }
        ICartRepository Carts { get; set; }
        ICategoryRepository Categories { get; set; }
        ICustomerRepository Customers { get; set; }
        ICustomerContactInfoRepository CustomerContactInfo { get; set; }
        IImageRepository Images { get; set; }
        IMaterialRepository Materials { get; set; }
        IOrderDetailsRepository OrderDetails { get; set; }
        IOrderRepository Orders { get; set; }
        IShipperRepository Shippers { get; set; }
        IAppThemeRepository AppThemes { get; set; }
        IUserRepository Users { get; set; }
        int Save();
    }
}
