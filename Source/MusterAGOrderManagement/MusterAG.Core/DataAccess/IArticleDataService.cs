using MusterAG.BusinessLogic.Dto;

namespace MusterAG.BusinessLogic.DataAccess
{
    public interface IArticleDataService
    {
        IList<ArticleDto> GetAll();

        ArticleDto Get(int id);

        ArticleDto Create(ArticleDto articleDto);

        ArticleDto Update(int id, ArticleDto articleDto);

        bool Delete(int id);
    }
}
