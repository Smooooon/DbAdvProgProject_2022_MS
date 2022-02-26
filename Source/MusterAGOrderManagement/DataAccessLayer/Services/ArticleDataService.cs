using DataAccessLayer;
using MusterAG.DataAccessLayer.Dao;

namespace DataAccessLayer.Services
{
    public class ArticleDataService //: IArticleDataService
    {

        public ArticleDataService()
        {
        }

        public ArticleDao Create(ArticleDao articleDao)
        {
            using (DataContext context = new DataContext())
            {
                var createdResult = context.Add(articleDao);
                context.SaveChanges();

                articleDao = createdResult.Entity;
            }

            return articleDao;
        }

        public bool Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var articleToDelete = context.Articles.FirstOrDefault(a => a.Id == id);

                if (articleToDelete == null)
                    return false;

                context.Remove(articleToDelete);
                context.SaveChanges();

                return true;
            }
        }

        public ArticleDao Get(int id)
        {
            using (DataContext context = new DataContext())
            {
                ArticleDao? articleDao = context.Articles.FirstOrDefault(a => a.Id == id);

                if (articleDao == null)
                    throw new ArgumentException($"Article mit der Id '{id}' nicht gefunden");

                return articleDao;
            }
        }

        public IList<ArticleDao> GetAll()
        {
            IList<ArticleDao> articleDtoList;

            using (DataContext context = new DataContext())
            {
                articleDtoList = context.Articles.ToList();

                return articleDtoList;
            }
        }

        public ArticleDao Update(int id, ArticleDao articleDao)
        {
            using (DataContext context = new DataContext())
            {
                articleDao.Id = id;

                context.Update(articleDao);
                context.SaveChanges();

                return articleDao;
            }
        }
    }
}
