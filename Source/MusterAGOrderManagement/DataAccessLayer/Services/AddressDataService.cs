﻿using DataAccessLayer;
using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class AddressDataService
    {

        public AddressDataService()
        {
        }

        public AddressDao Create(AddressDao addressDao)
        {
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(addressDao);
                context.SaveChanges();

                addressDao = createdResult.Entity;
            }

            return addressDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var addressToDelete = context.Addresses.FirstOrDefault(a => a.Id == id);

                if (addressToDelete == null)
                    return false;

                context.Remove(addressToDelete);
                context.SaveChanges();

                return true;
            }
        }

        public AddressDao Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                AddressDao? addressDao = context.Addresses.FirstOrDefault(a => a.Id == id);

                if (addressDao == null)
                    throw new ArgumentException($"Address mit der Id '{id}' nicht gefunden");

                return addressDao;
            }
        }

        public IList<AddressDao> GetAll()
        {
            IList<AddressDao> addressDtoList;

            using (DataContext context = new DataContext())
            {
                addressDtoList = context.Addresses.ToList();

                return addressDtoList;
            }
        }

        public AddressDao Update(AddressDao addressDao)
        {
            using (DataContext context = new DataContext())
            {
                context.Update(addressDao);
                context.SaveChanges();

                return addressDao;
            }
        }
    }
}
