using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAGOrderManagement.Model.ArticleGroup
{
    public class ArticleGroupItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? HigherLevelArticleGroupId { get; set; }
    }
}
