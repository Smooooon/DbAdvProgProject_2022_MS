using DataAccessLayer.Services;
using MusterAG.BusinessLogic.Dto;
using MusterAG.BusinessLogic.Mapping;
using MusterAG.DataAccessLayer.Dao;

namespace MusterAG.BusinessLogic.Domain
{
    public class PositionDomain
    {
        public PositionDataService _positionDataService = new PositionDataService();

        public IList<PositionDto> GetPositions()
        {
            IList<PositionDto> positionDtoList = new List<PositionDto>();

            IList<PositionDao> positionDaoList = _positionDataService.GetAll();

            foreach (PositionDao positionDao in positionDaoList)
                positionDtoList.Add(positionDao.ToDto());

            return positionDtoList;
        }

        public bool UpdatePositions(IList<PositionDto> positionDtoList)
        {
            bool success = true;

            foreach (PositionDto positionDto in positionDtoList)
            {
                PositionDao positionDao = positionDto.ToDao();
                PositionDao updatedPositionDao = _positionDataService.Update(positionDao);

                if (updatedPositionDao == null)
                    success = false;
            }

            return success;
        }

        public PositionDto CreatePosition(PositionDto positionDto)
        {
            PositionDao positionDao = positionDto.ToDao();
            PositionDao createdPositionDao = _positionDataService.Create(positionDao);

            return createdPositionDao.ToDto();
        }

        public bool DeletePosition(int positionIdToDelete)
        {
            return _positionDataService.Delete(positionIdToDelete);
        }
    }
}
