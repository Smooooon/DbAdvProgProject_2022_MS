using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.BusinessLogic.Dto
{
    public class ArticleDto : BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ArticleGroupId { get; set; }
        public ArticleGroupDto ArticleGroup { get; set; }
    }
}
