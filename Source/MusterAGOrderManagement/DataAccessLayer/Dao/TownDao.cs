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
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual CountryDao Country { get; set; }
    }
}
