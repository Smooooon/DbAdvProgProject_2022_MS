using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class ArticleGroupDataService
    {

        public ArticleGroupDataService()
        {
        }

        public ArticleGroupDao Create(ArticleGroupDao articleGroupDao)
        {
            articleGroupDao.HigherLevelArticleGroup = null;
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(articleGroupDao);
                context.SaveChanges();

                articleGroupDao = createdResult.Entity;
            }

            return articleGroupDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var articleToDelete = context.ArticleGroups.FirstOrDefault(a => a.Id == id);

                if (articleToDelete == null)
                    return false;

                context.Remove(articleToDelete);
                context.SaveChanges();

                return true;
            }
        }

        public ArticleGroupDao Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                ArticleGroupDao? articleGroupDao = context.ArticleGroups.FirstOrDefault(a => a.Id == id);

                if (articleGroupDao == null)
                    throw new ArgumentException($"ArticleGroup mit der Id '{id}' nicht gefunden");

                return articleGroupDao;
            }
        }

        public IList<ArticleGroupDao> GetAll()
        {
            IList<ArticleGroupDao> articleGroupDtoList;

            using (DataContext context = new DataContext())
            {
                articleGroupDtoList = context.ArticleGroups.Include("HigherLevelArticleGroup").Include("Articles").ToList();

                return articleGroupDtoList;
            }
        }

        public ArticleGroupDao Update(ArticleGroupDao articleGroupDao)
        {
            //Objekt ignorieren
            articleGroupDao.HigherLevelArticleGroup = null;

            using (DataContext context = new DataContext())
            {
                context.Update(articleGroupDao);
                context.SaveChanges();

                return articleGroupDao;
            }
        }

        //public void ArticelGroupeTree(ArticleGroupDao articleGroupDao)
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        context.Update(articleGroupDao);
        //        context.SaveChanges();

        //        return articleGroupDao;
        //    }
        //}

    }
}
