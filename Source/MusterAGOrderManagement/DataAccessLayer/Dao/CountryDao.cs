using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class CountryDao : BaseDao
    {
        public CountryDao()
        {
            this.Towns = new HashSet<TownDao>();
        }
        public string Name { get; set; }
        public virtual ICollection<TownDao> Towns { get; set; }
    }
}
