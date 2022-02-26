﻿using MusterAG.BusinessLogic.Dto;
using MusterAG.DataAccessLayer.Dao;
using MusterAGOrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAGOrderManagement.Mapping
{
    internal static class ArticleViewMapper
    {
        public static ArticleModel ToModel(this ArticleDto articleDto)
        {
            ArticleModel articleModel = new ArticleModel();
            articleModel.Id = articleDto.Id;
            articleModel.Name = articleDto.Name;
            articleModel.Price = articleDto.Price;
            articleModel.ArticleGroupId = articleDto.ArticleGroupId;

            return articleModel;
        }

        public static ArticleDto ToDto(this ArticleModel articleModel)
        {
            ArticleDto articleDto = new ArticleDto();
            articleDto.Id = articleModel.Id;
            articleDto.Name = articleModel.Name;
            articleDto.Price = articleModel.Price;
            articleDto.ArticleGroupId = articleModel.ArticleGroupId;

            return articleDto;
        }
    }
}
