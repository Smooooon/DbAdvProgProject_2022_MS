using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Position;

namespace MusterAGOrderManagement.Mapping
{
    internal static class PositionViewMapper
    {
        public static PositionItemModel ToModel(this PositionDto positionDto)
        {
            PositionItemModel positionModel = new PositionItemModel();
            positionModel.Id = positionDto.Id;
            positionModel.Quantity = positionDto.Quantity;
            positionModel.ArticleId = positionDto.ArticleId;
            positionModel.OrderId = positionDto.OrderId;

            return positionModel;
        }

        public static PositionDto ToDto(this PositionItemModel positionModel)
        {
            PositionDto positionDto = new PositionDto();
            positionDto.Id = positionModel.Id;
            positionDto.Quantity = positionModel.Quantity;
            positionDto.ArticleId = positionModel.ArticleId;
            positionDto.OrderId = positionModel.OrderId;

            return positionDto;
        }
    }
}
