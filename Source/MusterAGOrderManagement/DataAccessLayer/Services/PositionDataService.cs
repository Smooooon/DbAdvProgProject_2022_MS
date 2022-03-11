using Microsoft.EntityFrameworkCore;
using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class PositionDataService
    {

        public PositionDataService()
        {
        }

        public PositionDao Create(PositionDao positionDao)
        {
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(positionDao);
                context.SaveChanges();

                positionDao = createdResult.Entity;
            }

            return positionDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var positionToDelete = context.Positions.FirstOrDefault(a => a.Id == id);

                if (positionToDelete == null)
                    return false;

                context.Remove(positionToDelete);
                context.SaveChanges();

                return true;
            }
        }

        public PositionDao Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                PositionDao? positionDao = context.Positions.FirstOrDefault(a => a.Id == id);

                if (positionDao == null)
                    throw new ArgumentException($"Position mit der Id '{id}' nicht gefunden");

                return positionDao;
            }
        }

        public IList<PositionDao> GetAll()
        {
            IList<PositionDao> positionDtoList;

            using (DataContext context = new DataContext())
            {
                positionDtoList = context.Positions.Include(p => p.Article).Include(p => p.Order).ToList();

                return positionDtoList;
            }
        }

        public PositionDao Update(PositionDao positionDao)
        {
            //Objekt ignorieren
            positionDao.Article = null;
            positionDao.Order = null;

            using (DataContext context = new DataContext())
            {
                context.Update(positionDao);
                context.SaveChanges();

                return positionDao;
            }
        }
    }
}
