using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Position;

namespace MusterAGOrderManagement.Mapping
{
    internal static class PositionViewMapper
    {
        public static PositionItemModel ToModel(this PositionDto positionDto)
        {
            if (positionDto == null)
                return null;

            PositionItemModel positionModel = new PositionItemModel();
            positionModel.Id = positionDto.Id;
            positionModel.Quantity = positionDto.Quantity;
            positionModel.ArticleId = positionDto.ArticleId;
            positionModel.OrderId = positionDto.OrderId;
            positionModel.Article = positionDto.Article.ToModel();
            positionModel.Order = positionDto.Order.ToModel();

            return positionModel;
        }

        public static PositionDto ToDto(this PositionItemModel positionModel)
        {
            if (positionModel == null)
                return null;

            PositionDto positionDto = new PositionDto();
            positionDto.Id = positionModel.Id;
            positionDto.Quantity = positionModel.Quantity;
            positionDto.ArticleId = positionModel.ArticleId;
            positionDto.OrderId = positionModel.OrderId;
            positionDto.Article = positionModel.Article.ToDto();
            positionDto.Order = positionModel.Order.ToDto();

            return positionDto;
        }
    }
}
