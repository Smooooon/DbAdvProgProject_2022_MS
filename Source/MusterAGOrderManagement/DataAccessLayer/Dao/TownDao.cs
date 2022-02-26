using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class TownDao : BaseDao
    {
        public int PLZ { get; set; }
        public int Name { get; set; }
    }
}
