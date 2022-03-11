using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class PositionDomainMapper
    {
        public static PositionDao ToDao(this PositionDto positionDto)
        {
            if (positionDto == null)
                return null;

            PositionDao positionDao = new PositionDao();
            positionDao.Id = positionDto.Id;
            positionDao.Quantity = positionDto.Quantity;
            positionDao.ArticleId = positionDto.ArticleId;
            positionDao.OrderId = positionDto.OrderId;
            positionDao.Article = positionDto.Article.ToDao();
            positionDao.Order = positionDto.Order.ToDao();

            return positionDao;
        }

        public static PositionDto ToDto(this PositionDao positionDao)
        {
            if (positionDao == null)
                return null;

            PositionDto positionDto = new PositionDto();
            positionDto.Id = positionDao.Id;
            positionDto.Quantity = positionDao.Quantity;
            positionDto.ArticleId = positionDao.ArticleId;
            positionDto.OrderId = positionDao.OrderId;
            positionDto.Article = positionDao.Article.ToDto();
            positionDto.Order = positionDao.Order.ToDto();

            return positionDto;
        }

        public static PositionDto ToDtoWithoutOrder(this PositionDao positionDao)
        {
            if (positionDao == null)
                return null;

            PositionDto positionDto = new PositionDto();
            positionDto.Id = positionDao.Id;
            positionDto.Quantity = positionDao.Quantity;
            positionDto.ArticleId = positionDao.ArticleId;
            positionDto.OrderId = positionDao.OrderId;
            positionDto.Article = positionDao.Article.ToDto();

            return positionDto;
        }

        public static ICollection<PositionDto> ToDto(this ICollection<PositionDao> positionDaoList)
        {
            if (positionDaoList == null)
                return null;

            ICollection<PositionDto> positionDtoList = new List<PositionDto>();

            foreach (PositionDao positionDao in positionDaoList)
            {
                positionDtoList.Add(positionDao.ToDtoWithoutOrder());
            }

            return positionDtoList;
        }
    }
}
