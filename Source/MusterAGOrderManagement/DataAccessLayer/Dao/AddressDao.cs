using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class AddressDao : BaseDao
    {
        public string Street { get; set; }
        public int TownId { get; set; }
    }
}
