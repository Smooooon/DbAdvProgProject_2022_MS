using MusterAG.BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.BusinessLogic.Dto
{
    public class ArticleGroupDto : BaseDto
    {
        public string Name { get; set; }
        public int? HigherLevelArticleGroupId { get; set; }
    }
}
