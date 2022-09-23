using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
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

        public CustomerDao Get(int id, DateTime temporalQueryTime)
        {
            //Temporale Daten werden in UTC gespeichert
            temporalQueryTime = temporalQueryTime.ToUniversalTime();

            using (DataContext context = new DataContext())
            {
                CustomerDao? customerDao = context.Customers.TemporalAsOf(temporalQueryTime.ToUniversalTime()).FirstOrDefault(a => a.Id == id);

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
                customerDtoList = context.Customers.Include("Address").ToList();

                return customerDtoList;
            }
        }

        public IList<CustomerDao> GetAllTemporal(DateTime temporalQueryTime)
        {
            IList<CustomerDao> customerDtoList;

            //Temporale Daten werden in UTC gespeichert
            temporalQueryTime = temporalQueryTime.ToUniversalTime();

            using (DataContext context = new DataContext())
            {
                customerDtoList = context.Customers.TemporalAsOf(temporalQueryTime.ToUniversalTime()).ToList();

                return customerDtoList;
            }
        }

        public CustomerDao Update(CustomerDao customerDao)
        {
            //Objekt ignorieren
            customerDao.Address = null;

            using (DataContext context = new DataContext())
            {
                context.Update(customerDao);
                context.SaveChanges();

                return customerDao;
            }
        }
    }
}
