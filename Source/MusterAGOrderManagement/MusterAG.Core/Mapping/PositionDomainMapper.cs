using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Mapping
{
    internal static class PositionDomainMapper
    {
        public static PositionDao ToDao(this PositionDto positionDto)
        {
            PositionDao positionDao = new PositionDao();
            positionDao.Id = positionDto.Id;
            positionDao.Quantity = positionDto.Quantity;
            positionDao.ArticleId = positionDto.ArticleId;
            positionDao.OrderId = positionDto.OrderId;

            return positionDao;
        }

        public static PositionDto ToDto(this PositionDao positionDao)
        {
            PositionDto positionDto = new PositionDto();
            positionDto.Id = positionDao.Id;
            positionDto.Quantity = positionDao.Quantity;
            positionDto.ArticleId = positionDao.ArticleId;
            positionDto.OrderId = positionDao.OrderId;

            return positionDto;
        }
    }
}
