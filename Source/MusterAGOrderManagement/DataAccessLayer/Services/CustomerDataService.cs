using DataAccessLayer;
using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class CustomerDataService
    {

        public CustomerDataService()
        {
        }

        public CustomerDao Create(CustomerDao customerDao)
        {
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(customerDao);
                context.SaveChanges();

                customerDao = createdResult.Entity;
            }

            return customerDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var customerToDelete = context.Customers.FirstOrDefault(a => a.Id == id);

                if (customerToDelete == null)
                    return false;

                context.Remove(customerToDelete);
                context.SaveChanges();

                return true;
            }
        }

        public CustomerDao Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                CustomerDao? customerDao = context.Customers.FirstOrDefault(a => a.Id == id);

                if (customerDao == null)
                    throw new ArgumentException($"Customer mit der Id '{id}' nicht gefunden");

                return customerDao;
            }
        }

        public IList<CustomerDao> GetAll()
        {
            IList<CustomerDao> customerDtoList;

            using (DataContext context = new DataContext())
            {
                customerDtoList = context.Customers.ToList();

                return customerDtoList;
            }
        }

        public CustomerDao Update(CustomerDao customerDao)
        {
            using (DataContext context = new DataContext())
            {
                context.Update(customerDao);
                context.SaveChanges();

                return customerDao;
            }
        }
    }
}
