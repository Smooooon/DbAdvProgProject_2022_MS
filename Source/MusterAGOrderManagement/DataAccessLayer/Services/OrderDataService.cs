using Microsoft.EntityFrameworkCore;
using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class OrderDataService
    {

        public OrderDataService()
        {
        }

        public OrderDao Create(OrderDao orderDao)
        {
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(orderDao);
                context.SaveChanges();

                orderDao = createdResult.Entity;
            }

            return orderDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var orderToDelete = context.Orders.FirstOrDefault(a => a.Id == id);

                if (orderToDelete == null)
                    return false;

                context.Remove(orderToDelete);
                context.SaveChanges();

                return true;
            }
        }

        public OrderDao Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                OrderDao? orderDao = context.Orders.FirstOrDefault(a => a.Id == id);

                if (orderDao == null)
                    throw new ArgumentException($"Order mit der Id '{id}' nicht gefunden");

                return orderDao;
            }
        }

        public IList<OrderDao> GetAll()
        {
            IList<OrderDao> orderDtoList;

            using (DataContext context = new DataContext())
            {
                orderDtoList = context.Orders.Include(o => o.Customer).Include(o => o.Positions).ThenInclude(p => p.Article).ToList();

                return orderDtoList;
            }
        }

        public OrderDao Update(OrderDao orderDao)
        {
            //Objekt ignorieren
            orderDao.Customer = null;

            using (DataContext context = new DataContext())
            {
                context.Update(orderDao);
                context.SaveChanges();

                return orderDao;
            }
        }
    }
}
