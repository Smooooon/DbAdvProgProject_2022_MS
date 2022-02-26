using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class ArticleDao : BaseDao
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ArticleGroupId { get; set; }
    }
}
