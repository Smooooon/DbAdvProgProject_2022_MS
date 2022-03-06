using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class OrderDataService
    {

        public OrderDataService()
        {
        }

        public OrderDao Create(OrderDao OrderDao)
        {
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(OrderDao);
                context.SaveChanges();

                OrderDao = createdResult.Entity;
            }

            return OrderDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var OrderToDelete = context.Orders.FirstOrDefault(a => a.Id == id);

                if (OrderToDelete == null)
                    return false;

                context.Remove(OrderToDelete);
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
            IList<OrderDao> OrderDtoList;

            using (DataContext context = new DataContext())
            {
                OrderDtoList = context.Orders.ToList();

                return OrderDtoList;
            }
        }

        public OrderDao Update(OrderDao OrderDao)
        {
            using (DataContext context = new DataContext())
            {
                context.Update(OrderDao);
                context.SaveChanges();

                return OrderDao;
            }
        }
    }
}
