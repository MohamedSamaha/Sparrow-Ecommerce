using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IRepository;
using SparrowManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitsManagementSystem.BussinessLogic.Logic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get ; set ; }
        public ICartRepository Carts { get; set; }
        public ICategoryRepository Categories { get; set; }
        public ICustomerRepository Customers { get; set; }
        public ICustomerContactInfoRepository CustomerContactInfo { get; set; }
        public IImageRepository Images { get; set; }
        public IMaterialRepository Materials { get; set; }
        public IOrderDetailsRepository OrderDetails { get; set; }
        public IOrderRepository Orders { get; set; }
        public IShipperRepository Shippers { get; set; }
		public IAppThemeRepository AppThemes { get; set; }
		public IUserRepository Users { get; set; }

		public UnitOfWork(
            ApplicationDbContext context,
            IAppThemeRepository AppThemes,
            IProductRepository Products,
            ICartRepository Carts,
            ICategoryRepository Categories,
            ICustomerRepository Customers,
            ICustomerContactInfoRepository CustomerContactInfo,
            IImageRepository Images,
            IMaterialRepository Materials,
            IOrderDetailsRepository OrderDetails,
            IOrderRepository Orders,
            IShipperRepository Shippers,
            IUserRepository Users)
        {
            _context = context;
            this.AppThemes = AppThemes;
            this.Products = Products;
            this.Carts = Carts;
            this.Categories = Categories;
            this.Customers = Customers;
            this.CustomerContactInfo = CustomerContactInfo;
            this.Images = Images;
            this.Materials = Materials;
            this.OrderDetails = OrderDetails;
            this.Orders = Orders;
            this.Shippers = Shippers;
            this.Users = Users;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
