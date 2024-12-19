using E_CommerceAPI.Models;
using E_CommerceAPI.Repository;

namespace E_CommerceAPI.UnitOfWork
{
    public class UnitOFWork
    {
        ECommerceContext db;
        GenericRepository<Product> productsRepository;
        GenericRepository<Order> ordersRepository;
        GenericRepository<OrderDetails> orderDetailsRepository;
        

        
        public UnitOFWork(ECommerceContext db)
        {
            this.db = db;
        }

        public GenericRepository<Product> ProductsRepositry
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new GenericRepository<Product>(db);
                }
                return productsRepository;
            }

        }
        public GenericRepository<Order> OrdersRepositry
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new GenericRepository<Order>(db);
                }
                return ordersRepository;
            }

        }
        public GenericRepository<OrderDetails> OrderDetailsRepositry
        {
            get
            {
                if (orderDetailsRepository == null)
                {
                    orderDetailsRepository = new GenericRepository<OrderDetails>(db);
                }
                return orderDetailsRepository;
            }

        }
        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}
