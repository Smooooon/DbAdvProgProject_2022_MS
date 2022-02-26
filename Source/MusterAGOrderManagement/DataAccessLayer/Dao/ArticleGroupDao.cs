using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class ArticleGroupDao : BaseDao
    {
        public string Name { get; set; }
        public int? HigherLevelArticleGroupId { get; set; }
    }
}
